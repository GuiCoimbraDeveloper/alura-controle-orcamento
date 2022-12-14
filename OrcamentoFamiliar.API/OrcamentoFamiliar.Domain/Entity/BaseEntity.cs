using FluentValidation;
using FluentValidation.Results;
using System.Text;

namespace OrcamentoFamiliar.Domain.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            _errors = new List<string>();
        }
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AlteretedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public bool IsValid() => _errors.Count == 0;
        private void AddErrorList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                _errors.Add(error.ErrorMessage);
            }
        }
        protected bool Validate<T, J>(T validator, J obj) where T : AbstractValidator<J>
        {
            var validation = validator.Validate(obj);
            if (validation.Errors.Count > 0)
                AddErrorList(validation.Errors);

            return IsValid();
        }
        protected string ErrorsToString()
        {
            var builder = new StringBuilder();
            foreach (var error in _errors)
            {
                builder.AppendLine(error);
            }

            return builder.ToString();
        }

    }
}
