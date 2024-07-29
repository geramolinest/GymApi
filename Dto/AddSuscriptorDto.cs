using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AddSuscriptorDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public DateTime DateBirth { get; set; }
}
