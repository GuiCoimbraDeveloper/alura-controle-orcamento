using OrcamentoFamiliar.Domain.Entity.Request;
using OrcamentoFamiliar.Domain.Entity.Response;

namespace OrcamentoFamiliar.Application.Services.Interfaces
{
    public interface IReceitaService
    {
        Task<ReceitaResponse> Create(ReceitaRequest income);
        Task<List<ReceitaResponse>> GetList(string? descricao);
        Task<List<ReceitaResponse>> GetListMes(int ano, int mes);
        Task<ReceitaResponse> GetById(int id);
        Task<ReceitaResponse> Update(ReceitaRequest income, int id);
        Task Delete(int id);
    }
}
