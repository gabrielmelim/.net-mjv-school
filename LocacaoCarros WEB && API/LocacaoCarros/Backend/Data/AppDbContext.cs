using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Locacao>()
                .HasOne(loc => loc.Cliente)
                .WithMany(cli => cli.Locacoes)
                .HasForeignKey(loc => loc.IdCliente);

            modelBuilder.Entity<Locacao>()
                .HasOne(loc => loc.Veiculo)
                .WithMany(vei => vei.Locacoes)
                .HasForeignKey(loc => loc.IdVeiculo);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

    }
}
