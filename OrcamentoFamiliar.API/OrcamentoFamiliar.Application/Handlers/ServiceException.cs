namespace OrcamentoFamiliar.Application.Handlers
{
    public class ServiceException : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public ServiceException()
        {
            _errors = new List<string>();
        }

        public ServiceException(string message) : base(message)
        {
            _errors = new List<string>();
        }

        public ServiceException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
            _errors = new List<string>();
        }
    }
}
