namespace GymApi;

public class SalesProductRepository
{
    private readonly ApplicationDBContext _context;

    public SalesProductRepository(ApplicationDBContext context)
    {
        this._context = context;
    }

    public async Task<SaleProduct> AddSaleProduct(SaleProduct saleProduct)
    {
        this._context.SalesProducts.Add(saleProduct);
        
        await this._context.SaveChangesAsync();
        
        return saleProduct;
    }
}
