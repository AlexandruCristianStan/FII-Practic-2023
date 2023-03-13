using FIIPracticCars;
using FIIPracticCars.Repositories;
using FIIPracticCars.Repositories.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
  .AddDbContext<CarsContext>(options =>
    options.UseSqlServer("Server=LAPTOP-11\\SQLEXPRESS;Database=FIIPracticCars;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True")
    .LogTo(Console.WriteLine, minimumLevel: LogLevel.Information))
  .AddScoped<ICarsUnitOfWork, CarsUnitOfWork>()
  .AddScoped<IUserRepository, UserRepository>()
  .BuildServiceProvider();

TestUserRepo(serviceProvider);

static void TestUserRepo(ServiceProvider serviceProvider)
{
  var unitOfWork = serviceProvider.GetService<ICarsUnitOfWork>();
  var userRepo = serviceProvider.GetService<IUserRepository>();

  var newUser = new UserDto
  {
    FirstName = "Adam",
    LastName = "Smith",
    BirthDate = new DateTime(1990, 6, 1),
    Email = "adam.smith@example.com",
    PasswordHash = "1234567890"
  };

  userRepo.CreateUser(newUser);
  unitOfWork.SaveChanges();

  var searchUsers = userRepo.SearchByName("mith");
  unitOfWork.SaveChanges();

  userRepo.DeleteUser(searchUsers.FirstOrDefault()?.Id ?? 0);
  unitOfWork.SaveChanges();
}