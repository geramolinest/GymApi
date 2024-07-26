using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class UpdateRoleDto
{
    [Required]
    public string OldRole { get; set; }
    [Required]
    public string NewRoleName { get; set; }
}
