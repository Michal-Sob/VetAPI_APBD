using Microsoft.EntityFrameworkCore;
using VetAPI_APBD.Data;
using VetAPI_APBD.Models;
using VetAPI_APBD.Services.Interfaces;

namespace VetAPI_APBD.Services;

public class AnimalService : IAnimalService
{
    private readonly VetDbContext _context;

    public AnimalService(VetDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
    {
        return await _context.Animals.ToListAsync();
    }

    public async Task<Animal?> GetAnimalByIdAsync(int id)
    {
        return await _context.Animals
            .FindAsync(id);
    }

    public async Task AddAnimalAsync(Animal animal)
    {
        await _context.Animals.AddAsync(animal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAnimalAsync(Animal animal)
    {
        _context.Animals.Update(animal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnimalAsync(int id)
    {
        var animal = await GetAnimalByIdAsync(id);
        if (animal != null)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Visit>> GetAllVisitsAsync(int animalId)
    {
        var visits = await _context.Visits
            .Include(v => v.Animal)
            .Where(v => v.Animal.Id == animalId)
            .ToListAsync();

        return visits;
    }
}