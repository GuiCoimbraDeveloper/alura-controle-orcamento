using FluentValidation;

namespace OrcamentoFamiliar.Domain.Entity.Validators
{
    public class ReceitasValidator : AbstractValidator<Receitas>
    {
        public ReceitasValidator()
        {
            Include(new BaseValidator());
        }
    }
}
