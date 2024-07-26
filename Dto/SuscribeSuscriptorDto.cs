using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class SuscribeSuscriptorDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public DateTime DateBirth { get; set; }
    [Required]
    public AddSuscriptionDto Suscription { get; set; }
}
