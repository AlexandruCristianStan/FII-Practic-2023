using Bogus.Bson;
using FIIPracticCars.Services.Models;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace FIIPracticCars.Services
{
  public class CryptographyService : ICryptographyService
  {
    const int _hashBytesLength = 24;
    public HashedPassword HashPasswordWithSaltGeneration(string password)
    {
      var salt = RandomNumberGenerator.GetBytes(24);

      var argon2 = GetAlgorithm(password, salt);

      return new HashedPassword(ToBase64String(argon2.GetBytes(_hashBytesLength)), ToBase64String(salt));
    }

    public HashedPassword HashPassword(string password, string salt)
    {
      var argon2 = GetAlgorithm(password, FromBase64String(salt));
      return new HashedPassword(ToBase64String(argon2.GetBytes(_hashBytesLength)), salt);
    }

    private Argon2id GetAlgorithm(string password, byte[] salt)
    {
      if(password == null)
      {
        throw new ArgumentNullException("password");
      }
      return new Argon2id(Encoding.UTF8.GetBytes(password))
      {
        Iterations = 4,
        Salt = salt,
        MemorySize = 1024 * 16,
        DegreeOfParallelism = 1
      };
    }

    private string ToBase64String(byte[] value)
    {
      return Convert.ToBase64String(value);
    }
    private byte[] FromBase64String(string value)
    {
      return Convert.FromBase64String(value);
    }
  }
}
