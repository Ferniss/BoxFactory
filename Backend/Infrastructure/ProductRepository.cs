using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    //instance of ProductDbContext called _context
    private readonly ProductDbContext _context;

    // ProductRepository constrcutor with ProductDbContext as argument
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    // can get all products there is
    public List<Product> GetAllProducts()
    {
        return _context.ProductTable.ToList();
    }

    // can create/post a product
    public Product CreateNewProduct(Product product)
    {
        _context.ProductTable.Add(product);
        _context.SaveChanges();
        return product;
    }

    // can get a product by id
    public Product GetProductById(int id)
    {
        return _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
    }

    // can build or rebuilding db
    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    // can put/update a product
    public Product PutProduct(Product product)
    {
        _context.ProductTable.Update(product);
        _context.SaveChanges();
        return product;
    }

    // can Patch/update a product
    public Product PatchProduct(Product product)
    {
        _context.ProductTable.Update(product);
        _context.SaveChanges();
        return product;
    }

    // can Delete a product
    public Product DeleteProduct(int id)
    {
        var productToDelete = _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        _context.ProductTable.Remove(productToDelete);
        _context.SaveChanges();
        return productToDelete;
    }
}