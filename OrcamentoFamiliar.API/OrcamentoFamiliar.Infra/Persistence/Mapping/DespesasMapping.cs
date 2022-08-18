using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Mapping
{
    public class DespesasMapping : BaseMapping<Despesas>
    {
        public override void Configure(EntityTypeBuilder<Despesas> builder)
        {
            base.Configure(builder);

            builder.ToTable("Despesas");

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.Categoria)
                .HasMaxLength(30);

        }
    }
}
