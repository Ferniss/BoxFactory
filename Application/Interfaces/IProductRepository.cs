using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IProductRepository
{
    // all api methods from Interface class
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(Product product);
    public Product GetProductById(int id);
    public void RebuildDB();
    public Product PutProduct(Product product);
    public Product PatchProduct(Product product);
    public Product DeleteProduct(int id);
   
}