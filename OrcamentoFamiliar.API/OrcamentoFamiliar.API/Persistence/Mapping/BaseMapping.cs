using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Persistence.Mapping
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id)
                 .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.AlteretedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
