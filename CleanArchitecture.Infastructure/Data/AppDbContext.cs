using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Configuration the DB connection string

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseNpgsql("Host=localhost; Database=CleanArcDb; Username=postgres; Password=Abcd1234");
    //     }
    // }

    public virtual DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
        });
    }
}
