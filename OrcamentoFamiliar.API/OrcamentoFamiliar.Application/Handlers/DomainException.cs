namespace OrcamentoFamiliar.Application.Handlers
{
    public class DomainException : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public DomainException()
        {
            _errors = new List<string>();
        }

        public DomainException(string message) : base(message)
        {
            _errors = new List<string>();
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
            _errors = new List<string>();
        }
    }
}
