using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AddSuscriptionTypeDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int DurationInDays { get; set; }
}
