using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Infra.Data.EntitiesConfiguration
{
    public class PortfolioConfigurartion : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Codigo).HasMaxLength(10).IsRequired();
            //builder.Property(x => x.Slug).HasMaxLength(100);

            builder.HasOne(u => u.Usuario)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(f => f.UsuarioId);

            //builder.HasData(
            //    new Portfolio(1,"Padrão","Portifólio inicial para novos clientes", "PP")    
            //);

        }
    }
}
