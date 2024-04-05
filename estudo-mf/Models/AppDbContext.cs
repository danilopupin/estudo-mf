using Microsoft.EntityFrameworkCore;

namespace estudo_mf.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculos> Veiculo { get; set;}
    }
}
