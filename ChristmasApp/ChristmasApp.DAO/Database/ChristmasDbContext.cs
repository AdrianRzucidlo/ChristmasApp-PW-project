using Microsoft.EntityFrameworkCore;
using Rzucidlo.ChristmasApp.Core.Models;

namespace Rzucidlo.ChristmasApp.DAO.Database;

public class ChristmasDbContext : DbContext
{
    public DbSet<Children> Childrens { get; set; }
    public DbSet<Present> Presents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ChristmasDb;Trusted_Connection=true;TrustServerCertificate=true;");
    }
}