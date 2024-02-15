using Microsoft.EntityFrameworkCore;

namespace OnePieceTCGResultsApi.Entities;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Color> Colors { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Leader> Leaders { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Color>().HasData(
                Enum.GetValues(typeof(ColorId))
                    .Cast<ColorId>()
                    .Select(e => new Color()
                    {
                        ColorId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Role>().HasData(
                Enum.GetValues(typeof(RoleId))
                    .Cast<RoleId>()
                    .Select(e => new Role()
                    {
                        RoleId = e,
                        Name = e.ToString()
                    }));
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ApiDbConnectionString"));
    }
}