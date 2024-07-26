using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AddSuscriptionDto
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public int SuscriptionTypeId { get; set; }
}
