using FIIPracticCars.Repositories;

namespace FIIPracticCars
{
  public class CarsUnitOfWork : IDisposable
  {
    private bool disposedValue;
    private readonly CarsContext carContext;
    private IUserRepository? userRepository;

    public CarsUnitOfWork(CarsContext carContext)
    {
      this.carContext = carContext;
    }

    public IUserRepository UserRepository
    {
      get
      {
        if(userRepository == null)
        {
          userRepository = new UserRepository(carContext);
        }
        return userRepository;
      }
    }

    public void Save()
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
