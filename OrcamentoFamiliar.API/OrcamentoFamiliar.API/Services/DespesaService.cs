using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Services
{
    public class DespesaService : IDespesaService
    {
        #region Construtor
        private readonly IDespesasRepository _despesaRepository;

        public DespesaService(IDespesasRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }
        #endregion

        public async Task<string> Create(Despesas despesa)
        {
            try
            {
                if (await VerifydespesaDescription(despesa.Descricao, despesa.Data))
                    return "Despesa já cadastrada";

                await _despesaRepository.Insert(despesa);

                var result = _despesaRepository.Get(despesa.Id);

                return result.Id.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar Despesa", ex);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var despesa = await _despesaRepository.Get(id);
                if (despesa == null)
                    return "Despesa não existe";

                await _despesaRepository.Delete(despesa);

                return "Despesa excluída com sucesso!";
            }
            catch (Exception)
            {
                return "Erro na exclusão da Despesa!";
            }
        }

        public async Task<Despesas> GetById(int id)
        {
            try
            {
                var result = await _despesaRepository.Get(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IOrderedEnumerable<Despesas>> GetList(string? descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                    descricao = "";

                var result = await _despesaRepository.List(descricao);
                var aux = result.OrderByDescending(x => x.Data);

                return aux;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IOrderedEnumerable<Despesas>> GetListMes(int ano, int mes)
        {
            try
            {
                var result = await _despesaRepository.ListMes(ano, mes);
                var aux = result.OrderByDescending(x => x.Data);

                return aux;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(Despesas despesa)
        {
            try
            {
                if (await VerifydespesaDescription(despesa.Descricao, despesa.Data))
                    return "Jà existe uma Despesa com essa descrição! Operação Cancelada";

                await _despesaRepository.Update(despesa);

                return "ok";
            }
            catch (Exception ex)
            {
                return $"Erro na atualização da Despesa: {ex.Message}";
            }
        }

        #region Private Methods
        private async Task<bool> VerifydespesaDescription(string descricao, DateTime date)
        {
            var verifydespesa = await _despesaRepository.List(x => x.Descricao == descricao && x.Data.Month == date.Month && x.Data.Year == date.Year);
            if (verifydespesa.Any())
                return true;

            return false;
        }
        #endregion
    }
}
