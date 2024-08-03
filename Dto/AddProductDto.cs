using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AddProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
}
