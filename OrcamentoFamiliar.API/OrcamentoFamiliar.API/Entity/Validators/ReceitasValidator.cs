using FluentValidation;

namespace OrcamentoFamiliar.API.Entity.Validators
{
    public class ReceitasValidator : AbstractValidator<Receitas>
    {
        public ReceitasValidator()
        {
            Include(new BaseValidator());
        }
    }
}
