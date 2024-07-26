namespace GymApi;

public interface ISuscriptionsTypesRepository
{
    Task<IEnumerable<SuscriptionType>> GetAll();
    Task<SuscriptionType> GetById(int id);
    Task<SuscriptionType> AddSuscriptionType(SuscriptionType suscriptionType);
    Task<SuscriptionType> UpdateSuscriptionType(SuscriptionType suscriptionType);
    Task RemoveSuscriptionType(SuscriptionType suscriptionType);
}
