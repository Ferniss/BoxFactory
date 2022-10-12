using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{

    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllProducts()
    {
        return _context.ProductTable.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}