using OrcamentoFamiliar.Domain.Entity.Enum;
using OrcamentoFamiliar.Domain.Entity.Validators;

namespace OrcamentoFamiliar.Domain.Entity
{
    public class Despesas : BaseEntity
    {
        public EnumCategoria Categoria { get; set; } = EnumCategoria.Outras;


        public bool Validate() => base.Validate(new DespesasValidator(), this);
    }
}
