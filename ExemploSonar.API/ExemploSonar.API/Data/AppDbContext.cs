using ExemploSonar.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploSonar.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Registro> Registros { get; set; }
    }
}
