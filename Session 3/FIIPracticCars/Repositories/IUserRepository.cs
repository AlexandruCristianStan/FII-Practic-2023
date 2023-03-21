using FIIPracticCars.Repositories.Dtos;

namespace FIIPracticCars.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(UserDto userDto);
        IEnumerable<UserDto> SearchByName(string searchTerm);
        void DeleteUser(int userId);
        List<UserDto> GetAll();

        void UpdateUser(UserDto userDto);
        UserDto? GetUser(int userId);
    }
}
