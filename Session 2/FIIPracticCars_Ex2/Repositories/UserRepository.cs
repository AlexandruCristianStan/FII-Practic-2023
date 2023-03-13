using FIIPracticCars.Entities;
using FIIPracticCars.Repositories.Dtos;

namespace FIIPracticCars.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly CarsContext _context;

    public UserRepository(CarsContext context)
    {
      _context = context;
    }

    public void CreateUser(UserDto userDto)
    {
      if (userDto == null) throw new ArgumentNullException(nameof(userDto));
      if (string.IsNullOrEmpty(userDto.FirstName)) throw new ArgumentException($"{nameof(userDto.FirstName)} cannot be null or empty.");
      if (string.IsNullOrEmpty(userDto.LastName)) throw new ArgumentException($"{nameof(userDto.LastName)} cannot be null or empty.");
      if (string.IsNullOrEmpty(userDto.Email)) throw new ArgumentException($"{nameof(userDto.Email)} cannot be null or empty.");

      if (_context.Users.Any(u => u.Email == userDto.Email))
      {
        throw new Exception("Cannot insert a new User with the same Email.");
      }

      var userEntity = new User
      {
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Email = userDto.Email,
        BirthDate = userDto.BirthDate,
        PasswordHash = userDto.PasswordHash,
        RegistrationDate = DateTime.UtcNow,
      };

      _context.Users.Add(userEntity);
    }

    public void DeleteUser(int userId)
    {
      if(userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));

      var userToDelete = _context.Users.Find(userId);

      if (userToDelete != null)
      {
        _context.Users.Remove(userToDelete);
      }
    }

    public IEnumerable<UserDto> SearchByName(string searchTerm)
    {
      return _context.Users
         .Where(u => u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm))
         .Select(u => new UserDto
         {
           Id = u.Id,
           FirstName = u.FirstName,
           LastName = u.LastName,
           Email = u.Email,
           BirthDate = u.BirthDate,
           PasswordHash = u.PasswordHash
         })
         .ToList();
    }
  }
}
