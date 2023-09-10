using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("", 
            new MySqlServerVersion("10"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Will apply all configurations found it this assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}