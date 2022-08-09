using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Services.Interfaces
{
    public interface IDespesaService
    {
        Task<string> Create(Despesas income);
        Task<IOrderedEnumerable<Despesas>> GetList();
        Task<Despesas> GetById(int id);
        Task<string> Update(Despesas income);
        Task<string> Delete(int id);
    }
}
