
using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class SuscriptionsRepository : ISuscriptionsRepository
{
    private readonly ApplicationDBContext _dbContext;

    public SuscriptionsRepository(ApplicationDBContext dbContext)
    {   
        this._dbContext = dbContext;
    }
    public async Task<Suscription> AddSuscription(Suscription suscription)
    {
        this._dbContext.Add(suscription);
        await this._dbContext.SaveChangesAsync();
        return suscription;
    }

    public async Task<int> DeleteSuscription(int id)
    {
        var entity = await this._dbContext.Suscriptions.FirstOrDefaultAsync(x => x.Id == id);

        this._dbContext.Remove(entity);

        await this._dbContext.SaveChangesAsync();

        return id;
    }

    public async Task<Suscription> GetSuscription(int id)
    {
        return await this._dbContext.Suscriptions.Include(x => x.SuscriptionType).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Suscription>> GetSuscriptions()
    {
        return await this._dbContext.Suscriptions.Include(x => x.SuscriptionType).ToListAsync();                
    }

    public async Task<Suscription> UpdateSuscription(Suscription suscription)
    {
        this._dbContext.Update(suscription);
        
        await this._dbContext.SaveChangesAsync();
        
        return suscription;
    }
}
