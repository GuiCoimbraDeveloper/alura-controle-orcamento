using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Request;
using OrcamentoFamiliar.API.Entity.Response;

namespace OrcamentoFamiliar.API.Services.Interfaces
{
    public interface IDespesaService
    {
        Task<DespesaResponse> Create(DespesaRequest income);
        Task<List<DespesaResponse>> GetList(string? descricao);
        Task<List<DespesaResponse>> GetListMes(int ano, int mes);

        Task<DespesaResponse> GetById(int id);
        Task<DespesaResponse> Update(DespesaRequest income, int id);
        Task Delete(int id);
    }
}
