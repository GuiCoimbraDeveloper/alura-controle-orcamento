using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Services.Interfaces
{
    public interface IReceitaService
    {
        Task<string> Create(Receitas income);
        Task<IOrderedEnumerable<Receitas>> GetList(string? descricao);
        Task<IOrderedEnumerable<Receitas>> GetListMes(int ano, int mes);
        Task<Receitas> GetById(int id);
        Task<string> Update(Receitas income);
        Task<string> Delete(int id);
    }
}
