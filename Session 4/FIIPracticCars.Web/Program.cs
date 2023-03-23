using FIIPracticCars.Repositories;
using FIIPracticCars;
using Microsoft.EntityFrameworkCore;
using FIIPracticCars.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSqlServer<CarsContext>(builder.Configuration.GetConnectionString("FIIPracticCars"))
  .AddScoped<ICarsUnitOfWork, CarsUnitOfWork>()
  .AddScoped<IUserRepository, UserRepository>()
  .AddScoped<ICryptographyService, CryptographyService>();

builder.Services.AddControllersWithViews();

//Configure authentication
builder.Services
  .AddAuthentication(AuthCarsConstants.Schema)
  .AddCookie(AuthCarsConstants.Schema);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
