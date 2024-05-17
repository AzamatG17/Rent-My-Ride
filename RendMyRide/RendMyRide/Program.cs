using Microsoft.EntityFrameworkCore;
using RendMyRide.DataAccess;
using RendMyRide.Extensions;
using RendMyRide.Infrastructure.JwtToken;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

// Add services to the container.
builder.Services.AddDbContext<RendMyRideDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentMyRideConnection")));

builder.Services.AddControllersWithViews();
builder.Services.ConfigureRepositories();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
