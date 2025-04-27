using VetAPI_APBD.Models;

namespace VetAPI_APBD.Data;
using Microsoft.EntityFrameworkCore;

public class VetDbContext : DbContext
{
    public VetDbContext(DbContextOptions<VetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Animal)
            .WithMany()
            .HasForeignKey(v => v.AnimalId);


        StaticData.Configure(modelBuilder);
    }
}