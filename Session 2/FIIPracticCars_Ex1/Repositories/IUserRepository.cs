using FIIPracticCars.Repositories.Dtos;

namespace FIIPracticCars.Repositories
{
  public interface IUserRepository
  {
    void CreateUser(UserDto userDto);
    IEnumerable<UserDto> SearchByName(string searchTerm);
    void DeleteUser(int userId);
  }
}
