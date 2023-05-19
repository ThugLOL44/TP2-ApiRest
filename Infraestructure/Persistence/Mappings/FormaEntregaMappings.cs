using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Mappings
{
    public class FormaEntregaMappings : IEntityTypeConfiguration<FormaEntrega>
    {
        public void Configure(EntityTypeBuilder<FormaEntrega> entityBuilder)
        {
            entityBuilder.ToTable("FormaEntrega");
            entityBuilder.HasKey(fe => fe.FormaEntregaId);
            entityBuilder
                .HasMany(fm => fm.Comanda)
                .WithOne(c => c.FormaEntrega);

            entityBuilder.Property(p => p.FormaEntregaId).IsRequired();
            entityBuilder.Property(p => p.Descripcion).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();

            entityBuilder.HasData(
                new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" },
                new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" },
                new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" }
                );
        }
    }
}
