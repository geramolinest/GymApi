using Microsoft.EntityFrameworkCore.Metadata;

namespace GymApi;

public interface ISaleProductRepository
{
    Task<SaleProduct> AddSaleProduct(int productId, int saleId);
}
