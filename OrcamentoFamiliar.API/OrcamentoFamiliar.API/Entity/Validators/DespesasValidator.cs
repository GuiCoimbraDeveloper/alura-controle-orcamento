using FluentValidation;

namespace OrcamentoFamiliar.API.Entity.Validators
{
    public class DespesasValidator : AbstractValidator<Despesas>
    {
        public DespesasValidator()
        {
            Include(new BaseValidator());
            RuleFor(x => x.Categoria)
                .IsInEnum()
                .NotNull()
                .NotEmpty();
        }
    }
}
