using MySqlX.XDevAPI.Common;

namespace GymApi;

public interface ISuscriptorRepository
{
    public Task<Suscriptor> AddSuscriptor(Suscriptor suscriptor);
    public Task<int> DeleteSuscriptor(Suscriptor suscriptor);
    public Task<Suscriptor> UpdateSuscriptor(Suscriptor suscriptor);
    public Task<Suscriptor> GetSuscriptor(int id);
    
    public Task<List<Suscriptor>> GetSuscriptors();
    public Task<Suscriptor> GetSuscriptorByEmail(string email);
}
