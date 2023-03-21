using FIIPracticCars.Repositories;
using FIIPracticCars;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarsContext>(options =>
    options.UseSqlServer("Server=Gorgan-PC02\\SQLEXPRESS;Database=FIIPracticCars;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True")
    .LogTo(Console.WriteLine, minimumLevel: LogLevel.Information))
  .AddScoped<ICarsUnitOfWork, CarsUnitOfWork>()
  .AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
