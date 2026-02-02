using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Soporte.Data;
using Soporte.Models;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("cn");

// DbContext para tu aplicación de negocio
builder.Services.AddDbContext<SoporteDbContext>(options =>
    options.UseSqlServer(connectionString));

// DbContext para Identity (ApplicationDbContext)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar Identity con cuentas individuales
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// MVC y Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// 👈 Registrar autorización explícitamente
builder.Services.AddAuthorization();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // primero
app.UseAuthorization();    // después

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Atms}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

