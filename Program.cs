using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext to the DI container
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/AdminLogin/Index";
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "AdminScheme"; // Varsayýlan scheme
})
.AddCookie("AdminScheme", options =>
{
    options.LoginPath = "/AdminLogin/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
})
.AddCookie("BarberScheme", options =>
{
    options.LoginPath = "/BarberLogin/Index";
});

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
