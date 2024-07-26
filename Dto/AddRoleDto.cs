using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AddRoleDto
{
    [Required]
    public string RoleName { get; set; }
}
