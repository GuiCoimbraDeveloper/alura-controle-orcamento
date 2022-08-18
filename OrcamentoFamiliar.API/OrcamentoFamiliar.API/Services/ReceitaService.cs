using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitasRepository _receitaRepository;

        public ReceitaService(IReceitasRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task<string> Create(Receitas receita)
        {
            try
            {
                if (await VerifyReceitaDescription(receita.Descricao, receita.Data))
                    return "Receita já cadastrada";

                await _receitaRepository.Insert(receita);

                var result = _receitaRepository.Get(receita.Id);

                return result.Id.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar receita", ex);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var receita = await _receitaRepository.Get(id);
                if (receita == null)
                    return "Receita não existe";

                await _receitaRepository.Delete(receita);

                return "Receita excluída com sucesso!";
            }
            catch (Exception)
            {
                return "Erro na exclusão da receita!";
            }
        }

        public async Task<Receitas> GetById(int id)
        {
            try
            {
                var result = await _receitaRepository.Get(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IOrderedEnumerable<Receitas>> GetList(string? descricao)
        {

            if (string.IsNullOrEmpty(descricao))
                descricao = "";

            var result = await _receitaRepository.List(descricao);
            var aux = result.OrderByDescending(x => x.Data);

            return aux;

        }

        public async Task<IOrderedEnumerable<Receitas>> GetListMes(int ano, int mes)
        {

            var result = await _receitaRepository.ListMes(ano, mes);
            var aux = result.OrderByDescending(x => x.Data);

            return aux;

        }

        public async Task<string> Update(Receitas receita)
        {
            try
            {
                if (await VerifyReceitaDescription(receita.Descricao, receita.Data))
                    return "Jà existe uma receita com essa descrição! Operação Cancelada";

                await _receitaRepository.Update(receita);

                return "ok";
            }
            catch (Exception ex)
            {
                return $"Erro na atualização da receita: {ex.Message}";
            }
        }

        #region Private Methods
        private async Task<bool> VerifyReceitaDescription(string descricao, DateTime date)
        {
            var verifyreceita = await _receitaRepository.List(x => x.Descricao == descricao && x.Data.Month == date.Month && x.Data.Year == date.Year);
            return verifyreceita.Any();
        }
        #endregion
    }
}
