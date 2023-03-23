namespace FIIPracticCars.Entities
{
  public class Model
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ModelYear { get; set; }
    public FuelType FuelType { get; set; }
    public Brand Brand { get; set; }
  }
}
