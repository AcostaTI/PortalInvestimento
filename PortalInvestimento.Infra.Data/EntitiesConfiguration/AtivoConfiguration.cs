using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Infra.Data.EntitiesConfiguration
{
    public class AtivoConfiguration : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Codigo).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(t => t.TaxaADM).HasPrecision(16,4).IsRequired();
            builder.Property(t => t.Tipo).HasConversion<int>();

        }
    }
}
