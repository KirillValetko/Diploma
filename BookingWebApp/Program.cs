using Microsoft.EntityFrameworkCore;
using BookingWebApp.DataAccess.Data;
using BookingWebApp.DataAccess.Interfaces;
using BookingWebApp.DataAccess.Repositories;
using BookingWebApp.BusinessLogic.Interfaces;
using BookingWebApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();

var config = new MapperConfiguration(cfg => cfg.AddProfile(new BookingWebApp.Logic.Mapper()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddDbContext<BookingDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingDBConnectionString") ?? throw new InvalidOperationException("Connection string not found.")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //options.AccessDeniedPath = new PathString("/Authentication");
    options.LoginPath = new PathString("/Authentication");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Authentication/Index";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hotel}/{action=ViewHotels}/{id?}");

app.Run();
