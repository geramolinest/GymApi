namespace GymApi;

public interface ISalesRepository
{
    Task<Sale> GetSaleById(int id);
    Task<List<Sale>> GetSalesBySuscriptor(int id);
    Task<List<Sale>> GetSales();
    Task<Sale> AddSale(Sale sale);
    Task<Sale> UpdateSale(Sale sale);
    Task<int> DeleteSale(Sale sale);
}
