using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class SuscriptionAddDto
{
    [Required]
    public int SuscriptorId { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public int SuscriptionTypeId { get; set; }

}
