using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure;

// ProductDbContext using DbContext
public class ProductDbContext : DbContext
{
    // ProductDbContext constructor using ProductDbContext with base
    public ProductDbContext(DbContextOptions<ProductDbContext> opts) :base(opts)
    {

    }

    // creating model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //auto crements id model
                modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    // setting product table that holds products
    public DbSet<Product> ProductTable { get; set; }
}