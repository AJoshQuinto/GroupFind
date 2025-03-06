using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GroupFind.Data.Models;
using GroupFind.Data; // Removed the incorrect 'Seed' namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ? Required for rendering Razor views

// Configure EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ? Serve static files (CSS, JS, images, etc.)
app.UseStaticFiles();

// ? Enable routing and middleware
app.UseRouting();
app.UseAuthorization();

// ? Ensure the default route is set correctly
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // ? Ensure Razor pages are mapped

// ? Seed database (only for first-time setup)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(context);
}

app.Run();
