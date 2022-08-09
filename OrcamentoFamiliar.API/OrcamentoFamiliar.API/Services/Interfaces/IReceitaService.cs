using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Services.Interfaces
{
    public interface IReceitaService
    {
        Task<string> Create(Receitas income);
        Task<IOrderedEnumerable<Receitas>> GetList();
        Task<Receitas> GetById(int id);
        Task<string> Update(Receitas income);
        Task<string> Delete(int id);
    }
}
