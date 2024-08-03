using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public List<SaleProduct> SalesProduct { get; set; }

}
