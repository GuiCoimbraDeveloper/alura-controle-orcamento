using OrcamentoFamiliar.API.Entity.Enum;
using OrcamentoFamiliar.API.Entity.Validators;

namespace OrcamentoFamiliar.API.Entity
{
    public class Despesas : BaseEntity
    {
        public EnumCategoria Categoria { get; set; } = EnumCategoria.Outras;


        public bool Validate() => base.Validate(new DespesasValidator(), this);
    }
}
