using Microsoft.EntityFrameworkCore;

namespace HotellApp.Data;

public class HotellContext : DbContext
{
    public HotellContext()
    {
    }

    public HotellContext(DbContextOptions<HotellContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=FredrikHotell;Trusted_Connection=True;TrustServerCertificate=true;");
    }
}