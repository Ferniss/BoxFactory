using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> opts) :base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
             modelBuilder.Entity<ProductDbContext>()
            .Property(prop => prop.Id)
            .ValueGenerateOnAdd();
    }

    public DbSet<Product> ProductTable { get; set; }
}