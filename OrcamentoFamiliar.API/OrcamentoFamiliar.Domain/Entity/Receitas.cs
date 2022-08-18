using OrcamentoFamiliar.Domain.Entity.Validators;

namespace OrcamentoFamiliar.Domain.Entity
{
    public class Receitas : BaseEntity
    {

        public bool Validate() => base.Validate(new ReceitasValidator(), this);
    }
}
