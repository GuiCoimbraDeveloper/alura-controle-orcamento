using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Persistence.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> Auth(string user, string password);
    }
}
