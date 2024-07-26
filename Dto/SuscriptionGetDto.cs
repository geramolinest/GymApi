namespace GymApi;

public class SuscriptionGetDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;    
    public SuscriptionTypeGetDto SuscriptionType { get; set; }
}
