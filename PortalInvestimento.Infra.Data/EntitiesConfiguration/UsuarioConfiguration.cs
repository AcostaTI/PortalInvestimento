using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();  
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(100).IsRequired();
            builder.Property(x => x.TipoAcesso).HasConversion<int>().IsRequired();
            //builder.Property(x => x.Slug).HasMaxLength(100);            

        }
    }
}
