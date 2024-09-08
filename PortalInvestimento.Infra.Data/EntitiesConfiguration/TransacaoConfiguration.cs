using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalInvestimento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Infra.Data.EntitiesConfiguration
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Preco).HasPrecision(16,4).IsRequired();
            builder.Property(x => x.DataTransacao).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();

            builder.HasOne(p => p.Portfolio)
                .WithMany(u => u.Transacoes)
                .HasForeignKey(f => f.PortfolioId);

            builder.HasOne(p => p.Ativo)
               .WithMany(u => u.Transacoes)
               .HasForeignKey(f => f.AtivoId);





        }
    }
}
