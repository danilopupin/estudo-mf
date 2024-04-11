using Microsoft.EntityFrameworkCore;

namespace estudo_mf.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculos> Veiculo { get; set;}

        public DbSet<Consumo> Consumos { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
