using Bogus;
using FIIPracticCars;
using FIIPracticCars.Entities;
using FIIPracticCars.Repositories.Dtos;
using Microsoft.EntityFrameworkCore;


var carsContext = new CarsContext();
//RunSampleQueries(carsContext);
//CreateNewUsers(carsContext);
//TestUserRepo(carsContext);

static void RunSampleQueries(CarsContext carsContext)
{

  // 1. List Users and their Vehicles
  var users = carsContext.Users
  .Include(u => u.Vehicles)
  .ThenInclude(v => v.Model)
  .ThenInclude(m => m.Brand)
  .ToList();

  Console.WriteLine("Results:");
  foreach (var user in users)
  {
    Console.WriteLine($"[{user.Id}] {user.FirstName}, {user.LastName}");
    foreach (var vehicle in user.Vehicles)
    {
      Console.WriteLine($"\t[{vehicle.LicensePlate}] {vehicle.Model.Brand.Name} {vehicle.Model.Name}");
    }
  }

  // 2. Select Lotus Users
  var lotusUsers = carsContext.Vehicles
    .Where(v => v.Model.Brand.Name == "Lotus")
    .SelectMany(v => v.Users)
    .Distinct()
    .ToList();

  Console.WriteLine("Lotus owners:");
  foreach (var user in lotusUsers)
  {
    Console.WriteLine($"[{user.Id}] {user.FirstName}, {user.LastName}");
  }

  // 3. Show all the vehicle Brands and Models
  var vehicleTypes = carsContext.Models
    .Select(m => new
    {
      Brand = m.Brand.Name,
      Model = m.Name,
      Fuel = m.FuelType.ToString()
    }).ToList();

  Console.WriteLine("All models:");
  foreach (var vehicleType in vehicleTypes)
  {
    Console.WriteLine($"{vehicleType.Brand} {vehicleType.Model} ({vehicleType.Fuel})");
  }

  // 4. List Users by First and Last Names Alphabetically
  var allUsers = carsContext.Users
    .OrderBy(u => u.FirstName)
    .ThenBy(u => u.LastName)
    .ToList();

  Console.WriteLine("Users ordered alphabetically:");
  foreach (var user in users)
  {
    Console.WriteLine($"[{user.Id}] {user.FirstName} {user.LastName}");
  }

  // 5. List users paginated
  var pageNumber = 1;
  var pageSize = 10;

  var paginatedUsers = carsContext.Users
    .OrderBy(u => u.FirstName)
    .ThenBy(u => u.LastName)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToList();

  Console.WriteLine("Users (page 1):");
  foreach (var user in paginatedUsers)
  {
    Console.WriteLine($"[{user.Id}] {user.FirstName} {user.LastName}");
  }

  // 6. Get number of vehicles for each brand
  var brandStatistics = carsContext.Vehicles
    .GroupBy(v => v.Model.Brand.Name)
    .Select(g => new { Brand = g.Key, Count = g.Count() })
    .ToList();

  foreach (var vehicleBrand in brandStatistics)
  {
    Console.WriteLine($"{vehicleBrand.Brand}: {vehicleBrand.Count}");
  }
}

static void CreateNewUsers(CarsContext carsContext)
{
  var userFaker = new Faker<User>()
  .RuleFor(u => u.FirstName, f => f.Name.FirstName())
  .RuleFor(u => u.LastName, f => f.Name.LastName())
  .RuleFor(u => u.BirthDate, f => f.Date.Between(DateTime.Now.AddYears(-50), DateTime.Now))
  .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
  .RuleFor(u => u.PasswordHash, f => f.Random.Hash(32))
  .RuleFor(u => u.RegistrationDate, f => f.Date.Past(1));

  var newUsers = userFaker.Generate(10);

  foreach (var user in newUsers)
  {
    carsContext.Users.Add(user);
  }

  carsContext.SaveChanges();
}

static void TestUserRepo(CarsContext carsContext)
{
  var unitOfWork = new CarsUnitOfWork(carsContext);
  var userRepo = unitOfWork.UserRepository;

  var newUser = new UserDto
  {
    FirstName = "Adam",
    LastName = "Smith",
    BirthDate = new DateTime(1990, 6, 1),
    Email = "adam.smith@example.com",
    PasswordHash = "1234567890"
  };

  userRepo.CreateUser(newUser);
  unitOfWork.Save();

  var searchUsers = userRepo.SearchByName("mith");
  unitOfWork.Save();

  userRepo.DeleteUser(searchUsers.FirstOrDefault()?.Id ?? 0);
  unitOfWork.Save();
}