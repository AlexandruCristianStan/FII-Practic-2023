namespace FIIPracticCars.Entities
{
  public class Vehicle
  {
    public int Id { get; set; }
    public string VIN { get; set; }
    public string? LicensePlate { get; set;}
    public DateTime? RegistrationDate { get; set; }
    public string? ExteriorColor { get; set; }

    public Model Model { get; set; }
    public List<User> Users { get; set; }
  }
}
