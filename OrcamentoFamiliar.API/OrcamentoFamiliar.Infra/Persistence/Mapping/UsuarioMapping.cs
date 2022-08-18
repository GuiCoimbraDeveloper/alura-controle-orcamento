using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public virtual void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");


            builder.Property(x => x.Id).HasColumnName("Id")
                   .IsRequired().ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Username).HasMaxLength(30);
            builder.Property(x => x.Password).HasMaxLength(30);
            builder.Property(x => x.Role).HasMaxLength(30);
        }
    }
}
