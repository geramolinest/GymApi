using System.ComponentModel.DataAnnotations;

namespace GymApi;

public class AsingRoleDto
{   
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Required]
    public string Role { get; set; }
}
