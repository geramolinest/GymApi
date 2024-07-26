using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GymApi;

[Index(nameof(Email), IsUnique = true)]
public class Suscriptor
{
    public int Id { get; set; }
    [EmailAddress]    
    public string Email { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime DateBirth { get; set; }
    public DateTime RegisterDate { get; set; }
    public int? SuscriptionId { get; set; }
    public Suscription Suscription { get; set; }
}
