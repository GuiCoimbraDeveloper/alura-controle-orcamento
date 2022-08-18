using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces
{
    public interface IDespesasRepository : IBaseRepository<Despesas>
    {
        Task<List<Despesas>> ListMes(int ano, int mes); 
    }
}
