using Application.DTOs;
namespace Domain.Interfaces;

public interface IProductService
{
    // all api methods from Interface class
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(PostProductDTO dto);
    public Product GetProductById(int id);
    public void RebuildDB();
    public Product PutProduct(int id, Product product);
    public Product PatchProduct(int id, Product product);
    public Product DeleteProduct(int id);
}