namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context; 
    
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }
}