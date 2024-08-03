namespace GymApi;

public interface IProductsRepository
{
    Task<Product> GetProductById(int id);
    Task<List<Product>> GetAllProducts();
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<int> DeleteProduct(Product product);    
}
