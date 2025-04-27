using VetAPI_APBD.Models;

namespace VetAPI_APBD.Services.Interfaces;

public interface IAnimalService
{
    Task<IEnumerable<Animal>> GetAllAnimalsAsync();
    Task<Animal?> GetAnimalByIdAsync(int id);
    Task AddAnimalAsync(Animal animal);
    Task UpdateAnimalAsync(Animal animal);
    Task DeleteAnimalAsync(int id);
    Task SaveChangesAsync();
    Task<List<Visit>> GetAllVisitsAsync(int animalId);
}