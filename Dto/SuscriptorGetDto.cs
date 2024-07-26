namespace GymApi;

public class SuscriptorGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime DateBirth { get; set; }
    public DateTime RegisterDate { get; set; }
    public SuscriptionGetDto Suscription { get; set; }
}
