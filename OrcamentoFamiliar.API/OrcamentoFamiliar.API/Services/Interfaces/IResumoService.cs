using OrcamentoFamiliar.API.Entity.Response;

namespace OrcamentoFamiliar.API.Services.Interfaces
{
    public interface IResumoService
    {
        public Task<ResumoResponse> GetResumo(int ano, int mes);
    }
}
