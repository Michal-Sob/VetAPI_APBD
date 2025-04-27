namespace VetAPI_APBD.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public Animal? Animal { get; set; }
    public int AnimalId { get; set; }
}