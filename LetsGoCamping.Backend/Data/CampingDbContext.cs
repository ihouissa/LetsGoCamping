using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LetsGoCamping.Models;

public class CampingDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    // Constructor for CampingDbContext that takes IConfiguration as a parameter.
    public CampingDbContext(IConfiguration configuration)
    {
        _configuration = configuration; // Assign the configuration to the private field.
    }

    // Configures the DbContext with options.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Get the connection string named "CampingDb" from the appsettings.json.
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        // Use SQL Server provider and pass the connection string to the DbContext options.
        optionsBuilder.UseSqlServer(connectionString);
    }

    // Define the Users table based on the User model.
    public DbSet<User> Users { get; set; }
}
