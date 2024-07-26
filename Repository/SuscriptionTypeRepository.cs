

using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class SuscriptionTypeRepository : ISuscriptionsTypesRepository
{
    private readonly ApplicationDBContext _dbContext;

    public SuscriptionTypeRepository(ApplicationDBContext dBContext)
    {
        this._dbContext = dBContext;
    }

    public async Task<SuscriptionType> AddSuscriptionType(SuscriptionType suscriptionType)
    {
        this._dbContext.Add(suscriptionType);
        await this._dbContext.SaveChangesAsync();

        return suscriptionType;
    }

    public async Task<IEnumerable<SuscriptionType>> GetAll()
    {
        return await this._dbContext.SuscriptionsTypes.ToListAsync();
    }

    public async Task<SuscriptionType> GetById(int id)
    {
        return await this._dbContext.SuscriptionsTypes.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task RemoveSuscriptionType(SuscriptionType suscriptionType)
    {
        this._dbContext.Update(suscriptionType);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<SuscriptionType> UpdateSuscriptionType(SuscriptionType suscriptionType)
    {
        this._dbContext.Update(suscriptionType);
        
        await this._dbContext.SaveChangesAsync();

        return suscriptionType;
    }

    public async Task<bool> ExistSuscriptionType(int id)
    {
        return await this._dbContext.SuscriptionsTypes.AnyAsync(x => x.Id == id);
    }
}
