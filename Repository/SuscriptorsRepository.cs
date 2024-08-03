
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class SuscriptorsRepository : ISuscriptorRepository
{
    private readonly ApplicationDBContext _dbContext;

    public SuscriptorsRepository(ApplicationDBContext dbContext)
    {        
        this._dbContext = dbContext;
    }

    public async Task<Suscriptor> AddSuscriptor(Suscriptor suscriptor)
    {
        this._dbContext.Add(suscriptor);
        await this._dbContext.SaveChangesAsync();
        return suscriptor;
    }

    public async Task<int> DeleteSuscriptor(Suscriptor suscriptor)
    {
        this._dbContext.Update(suscriptor);
        await this._dbContext.SaveChangesAsync();

        return suscriptor.Id;
    }

    public async Task<Suscriptor> GetSuscriptor(int id)
    {
        return await this._dbContext.Suscriptors.Include(x => x.Suscription).Include(x => x.Suscription.SuscriptionType).FirstOrDefaultAsync(x => x.Id == id && x.IsActive);    
    }

    public async Task<Suscriptor> UpdateSuscriptor(Suscriptor suscriptor)
    {
        this._dbContext.Update(suscriptor);
        await this._dbContext.SaveChangesAsync();
        return suscriptor;
    }

    public async Task<List<Suscriptor>> GetSuscriptors()
    {
        return await this._dbContext.Suscriptors.Include(x => x.Suscription).Include(x => x.Suscription.SuscriptionType).ToListAsync();                
    }

    public async Task<Suscriptor> GetSuscriptorByEmail(string email)
    {
        return await this._dbContext.Suscriptors.FirstOrDefaultAsync(x => x.Email.ToUpper().Equals(email.ToUpper()));
    }
}
