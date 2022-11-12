using Microsoft.EntityFrameworkCore;
using TransportCompany.Models;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddMvcCore().AddRazorViewEngine();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.MapPost("/api/orders", async (Order order, Context db) =>
{
    await db.Orders.AddAsync(order);
    await db.SaveChangesAsync();
    return order;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
