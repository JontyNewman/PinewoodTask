using Microsoft.EntityFrameworkCore;

namespace JontyNewman.PinewoodTask.Db;

public class CustomerDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Address);
    }
}