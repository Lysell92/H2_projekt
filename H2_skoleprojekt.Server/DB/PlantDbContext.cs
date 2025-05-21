using H2_skoleprojekt.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace H2_skoleprojekt.Server.DB
{
    public class PlantDbContext : DbContext
    {
    public PlantDbContext(DbContextOptions<PlantDbContext> options)
    : base(options) { }

    public DbSet<PlantDbModel>? plantdb { get; set; }
    }
}
