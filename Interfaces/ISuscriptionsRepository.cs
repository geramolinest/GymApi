namespace GymApi;

public interface ISuscriptionsRepository
{
    Task<Suscription> GetSuscription(int id);
    Task<List<Suscription>> GetSuscriptions();
    Task<Suscription> AddSuscription(Suscription suscription);
    Task<Suscription> UpdateSuscription(Suscription suscription);
    Task<int> DeleteSuscription(int id);

}
