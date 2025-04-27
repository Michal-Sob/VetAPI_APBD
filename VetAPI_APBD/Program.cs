using Microsoft.EntityFrameworkCore;
using VetAPI_APBD.Data;
using VetAPI_APBD.Models;
using VetAPI_APBD.Services;
using VetAPI_APBD.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VetDbContext>(options =>
    options.UseInMemoryDatabase("VetClinicDb"));


builder.Services.AddScoped<IAnimalService, AnimalService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<VetDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();


app.MapGet("/animals/getanimal/{id}", async (IAnimalService animalService, int id) =>
{
    var animal = await animalService.GetAnimalByIdAsync(id);
    return animal is not null ? Results.Ok(animal) : Results.NotFound();
});

app.MapGet("/animals/getallanimals", async (IAnimalService animalService) =>
{
    var animals = await animalService.GetAllAnimalsAsync();
    return Results.Ok(animals);
});

app.MapPost("/animals/createanimal", async (IAnimalService animalService, Animal animal) =>
{
    await animalService.AddAnimalAsync(animal);
    return Results.Created($"/animals/getanimal/{animal.Id}", animal);
});

app.MapPut("/animals/updateanimal", async (IAnimalService animalService, Animal animal) =>
{
    var existingAnimal = await animalService.GetAnimalByIdAsync(animal.Id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    existingAnimal.Name = animal.Name;
    existingAnimal.Category = animal.Category;
    existingAnimal.FurColor = animal.FurColor;
    existingAnimal.Mass = animal.Mass;
    
    await animalService.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("/animals/deleteanimal/{id}", async (IAnimalService animalService, int id) =>
{
    var existingAnimal = await animalService.GetAnimalByIdAsync(id);
    if (existingAnimal is null)
    {
        return Results.NotFound();
    }

    await animalService.DeleteAnimalAsync(id);
    return Results.Ok();
});

app.MapGet("/visit/getanimalvisits/{animalid}", async (IAnimalService animalService, int animalid) =>
{
    var visits = await animalService.GetAllVisitsAsync(animalid);
    
    return visits.Count == 0 ? Results.NotFound() : Results.Ok(visits);
});

app.MapPost("/visit/createvisit", async (VetDbContext dbContext, Visit visit) =>
{
    await dbContext.Visits.AddAsync(visit);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/visit/getanimalvisits/{visit.Animal?.Id}", visit);
});

app.Run();