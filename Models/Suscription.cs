using System.ComponentModel.DataAnnotations.Schema;

namespace GymApi;

public class Suscription
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int SuscriptionTypeId { get; set; }
    public SuscriptionType SuscriptionType { get; set; }
    public Suscriptor Suscriptor { get; set; }
}
