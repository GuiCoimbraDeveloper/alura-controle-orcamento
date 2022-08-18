using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces
{
    public interface IReceitasRepository : IBaseRepository<Receitas>
    {
        Task<List<Receitas>> ListMes(int ano, int mes);
    }
}
