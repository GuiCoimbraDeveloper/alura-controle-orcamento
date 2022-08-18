using OrcamentoFamiliar.Domain.Entity.Request;
using OrcamentoFamiliar.Domain.Entity.Response;

namespace OrcamentoFamiliar.Application.Services.Interfaces
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
