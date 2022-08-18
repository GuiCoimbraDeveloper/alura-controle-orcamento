using OrcamentoFamiliar.Domain.Entity.Response;

namespace OrcamentoFamiliar.Application.Services.Interfaces
{
    public interface IResumoService
    {
        public Task<ResumoResponse> GetResumo(int ano, int mes);
    }
}
