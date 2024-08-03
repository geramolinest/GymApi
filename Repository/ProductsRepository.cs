
using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDBContext _dbContext;

    public ProductsRepository(ApplicationDBContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Product> AddProduct(Product product)
    {
        this._dbContext.Products.Add(product);
        
        await this._dbContext.SaveChangesAsync();
        
        return product;
    }

    public async Task<int> DeleteProduct(Product product)
    {

        this._dbContext.Products.Remove(product);

        await this._dbContext.SaveChangesAsync();

        return product.Id;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await this._dbContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await this._dbContext.Products.FirstOrDefaultAsync( x=> x.Id == id);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        this._dbContext.Update(product);
        
        await this._dbContext.SaveChangesAsync();

        return product;
    }
}
