using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Mappings
{
    public class ComandaMappings : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> entityBuilder)
        {
            entityBuilder.ToTable("Comanda");
            entityBuilder.HasKey(c => c.ComandaId);

            entityBuilder
                .HasMany(c => c.ComandaMercaderia)
                .WithOne(cm => cm.Comanda)
                .IsRequired();

            entityBuilder.Property(p => p.ComandaId).ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.FormaEntregaId).IsRequired();
            entityBuilder.Property(p => p.PrecioTotal).IsRequired();
            entityBuilder.Property(p => p.Fecha).IsRequired();
        }
    }
}
