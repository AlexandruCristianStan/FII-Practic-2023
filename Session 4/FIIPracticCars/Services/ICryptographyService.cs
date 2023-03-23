using FIIPracticCars.Services.Models;

namespace FIIPracticCars.Services
{
  public interface ICryptographyService
  {
    HashedPassword HashPasswordWithSaltGeneration(string password);
    HashedPassword HashPassword(string password, string salt);
  }
}