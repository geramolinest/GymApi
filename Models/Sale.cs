namespace GymApi;

public class Sale
{
    public int Id { get; set; }
    public DateTime DateSale { get; set; }
    public decimal Total { get; set; }
    
    public int? SuscriptorId { get; set; }
    public Suscriptor Suscriptor { get; set; } = null;

    public List<SaleProduct> SalesProducts { get; set; }
}
