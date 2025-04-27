namespace VetAPI_APBD.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryEnum Category { get; set; }
    public double Mass { get; set; }
    public string FurColor { get; set; }
} 

public enum CategoryEnum
{
    Dog,
    Cat,
    Fish,
    Bird,
    Reptile,
    Other
}