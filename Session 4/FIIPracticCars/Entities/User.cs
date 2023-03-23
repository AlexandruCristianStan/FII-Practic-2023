namespace FIIPracticCars.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public IList<Vehicle> Vehicles { get; set; }
  }
}
