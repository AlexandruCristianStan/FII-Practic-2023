using FIIPracticCars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FIIPracticCars
{
  public class CarsContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<UserVehicle> UserVehicles { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Brand> Brands { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString =
        "Server=LAPTOP-11\\SQLEXPRESS;Database=FIIPracticCars;" +
        "Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
      optionsBuilder.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserVehicle>()
        .HasKey(uv => new { uv.UserId, uv.VehicleId });

      modelBuilder.Entity<User>()
        .HasMany(u => u.Vehicles)
        .WithMany(v => v.Users)
        .UsingEntity<UserVehicle>();
    }
  }
}
