using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=TP2-REST;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}


