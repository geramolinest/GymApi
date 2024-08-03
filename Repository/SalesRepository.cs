
using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class SalesRepository : ISalesRepository
{
    private readonly ApplicationDBContext _dbContext;

    public SalesRepository(ApplicationDBContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Sale> AddSale(Sale sale)
    {
        this._dbContext.Sales.Add(sale);
        await this._dbContext.SaveChangesAsync();
        return sale;
    }

    public async Task<int> DeleteSale(Sale sale)
    {
        this._dbContext.Sales.Remove(sale);

        await this._dbContext.SaveChangesAsync();

        return sale.Id;
    }

    public async Task<Sale> GetSaleById(int id)
    {
        return await this._dbContext.Sales.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Sale>> GetSales()
    {
        return this._dbContext.Sales.ToListAsync();
    }

    public Task<List<Sale>> GetSalesBySuscriptor(int id)
    {
        return this._dbContext.Sales.Where(x => x.SuscriptorId == id).Include(s => s.Suscriptor).Include( s=> s.SalesProducts ).ToListAsync();
    }


    public async Task<Sale> UpdateSale(Sale sale)
    {

        this._dbContext.Update(sale);
        await this._dbContext.SaveChangesAsync();

        return sale;
    } 
}
