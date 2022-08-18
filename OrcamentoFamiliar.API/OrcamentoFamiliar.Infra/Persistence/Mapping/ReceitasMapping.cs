using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Mapping
{
    public class ReceitasMapping : BaseMapping<Receitas>
    {
        public override void Configure(EntityTypeBuilder<Receitas> builder)
        {
            base.Configure(builder);

            builder.ToTable("Receitas");

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,4)");

        }
    }
}
