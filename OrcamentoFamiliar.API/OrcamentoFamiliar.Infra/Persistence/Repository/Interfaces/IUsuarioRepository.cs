using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> Auth(string user, string password);
    }
}
