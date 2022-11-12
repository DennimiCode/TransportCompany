using Microsoft.EntityFrameworkCore;

namespace TransportCompany.Models;

public class Context : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;

    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}