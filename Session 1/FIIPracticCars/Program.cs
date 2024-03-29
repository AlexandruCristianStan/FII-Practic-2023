﻿using FIIPracticCars;
using Microsoft.EntityFrameworkCore;

var carsContext = new CarsContext();


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