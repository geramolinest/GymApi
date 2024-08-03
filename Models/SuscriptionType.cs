using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class SuscriptionType
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public bool Enable { get; set; }
    public decimal Price { get; set; }
    
    [Required]
    public int DurationInDays { get; set; }
    public List<Suscription> Suscriptions { get; set; }
    
}
