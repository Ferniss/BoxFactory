using Application.DOTs;
using Domain;

namespace Application.Interfaces;

public interface IProductServices
{
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(ProductDTOs.PostProductDTO dto);
    public Product GetProductById(int id);
    public void RebuildDB();
    public Product UpdateProduct(int id, Product product);
    public Product DeleteProduct(int id);
}