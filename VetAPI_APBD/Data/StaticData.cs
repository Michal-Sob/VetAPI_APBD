using Microsoft.EntityFrameworkCore;
using VetAPI_APBD.Models;

namespace VetAPI_APBD.Data;

public static class StaticData
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>().HasData(
            new Animal
            {
                Id = 1,
                Name = "Max",
                Category = CategoryEnum.Dog,
                Mass = 25.5,
                FurColor = "Golden"
            },
            new Animal
            {
                Id = 2,
                Name = "Whiskers",
                Category = CategoryEnum.Cat,
                Mass = 4.2,
                FurColor = "White and Gray"
            },
            new Animal
            {
                Id = 3,
                Name = "Rocky",
                Category = CategoryEnum.Dog,
                Mass = 32.7,
                FurColor = "Black and Tan"
            },
            new Animal
            {
                Id = 4,
                Name = "Bubbles",
                Category = CategoryEnum.Fish,
                Mass = 0.1,
                FurColor = "Orange and White"
            },
            new Animal
            {
                Id = 5,
                Name = "Tweety",
                Category = CategoryEnum.Bird,
                Mass = 0.3,
                FurColor = "Yellow"
            },
            new Animal
            {
                Id = 6,
                Name = "Slinky",
                Category = CategoryEnum.Reptile,
                Mass = 1.5,
                FurColor = "Brown and Black"
            }
        );

        modelBuilder.Entity<Visit>().HasData(
            new Visit
            {
                Id = 1,
                Date = DateTime.Now.AddDays(-30),
                Description = "Annual checkup. Vaccinations updated.",
                Cost = 150,
                AnimalId = 1
            },
            new Visit
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-15),
                Description = "Treatment for ear infection.",
                Cost = 75,
                AnimalId = 2
            },
            new Visit
            {
                Id = 3,
                Date = DateTime.Now.AddDays(-7),
                Description = "Follow-up for skin condition.",
                Cost = 50,
                AnimalId = 1
            },
            new Visit
            {
                Id = 4,
                Date = DateTime.Now.AddDays(-2),
                Description = "Dental cleaning and examination.",
                Cost = 200,
                AnimalId = 3
            },
            new Visit
            {
                Id = 5,
                Date = DateTime.Now.AddDays(-1),
                Description = "Water quality check and fin treatment.",
                Cost = 30,
                AnimalId = 4
            }
        );
    }
}