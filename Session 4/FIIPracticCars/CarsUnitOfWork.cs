using FIIPracticCars.Repositories;

namespace FIIPracticCars
{
  public class CarsUnitOfWork : IDisposable, ICarsUnitOfWork
  {
    private bool disposedValue;
    private readonly CarsContext carContext;

    public CarsUnitOfWork(CarsContext carContext)
    {
      this.carContext = carContext;
    }

    public void SaveChanges()
    {
      carContext.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          carContext.Dispose();
        }

        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
