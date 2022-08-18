using AutoMapper;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Request;
using OrcamentoFamiliar.API.Entity.Response;
using OrcamentoFamiliar.API.Handler;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Services
{
    public class DespesaService : IDespesaService
    {
        #region Construtor
        private readonly IDespesasRepository _despesaRepository;
        private readonly IMapper _mapper;
        public DespesaService(IDespesasRepository despesaRepository, IMapper mapper)
        {
            _despesaRepository = despesaRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<DespesaResponse> Create(DespesaRequest despesa)
        {
            try
            {

                var entityDesc = await _despesaRepository.List(despesa.Descricao);
                if (entityDesc != default)
                {
                    var entityMes = await _despesaRepository.ListMes(despesa.Data.Year, despesa.Data.Month);
                    if (entityMes != default)
                        throw new DomainException("Não é possível existir duas despesas iguais no mesmo mês.");
                }

                var aux = _mapper.Map<Despesas>(despesa);
                aux.Validate();

                var despesaCreated = await _despesaRepository.Insert(aux);

                return _mapper.Map<DespesaResponse>(despesaCreated);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar Despesa", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var despesa = await _despesaRepository.Get(id);
                if (despesa is null)
                    throw new ServiceException("Nenhuma despesa encontrada para remoção");

                await _despesaRepository.Delete(despesa);
            }
            catch (Exception)
            {
                throw new Exception("Erro na exclusão da Despesa!");
            }
        }

        public async Task<DespesaResponse> GetById(int id)
        {
            var result = await _despesaRepository.Get(id);
            if (result is null)
                throw new ServiceException("Nenhuma despesa encontrada.");

            return _mapper.Map<DespesaResponse>(result);
        }

        public async Task<List<DespesaResponse>> GetList(string? descricao)
        {

            if (string.IsNullOrEmpty(descricao))
                descricao = "";

            var result = await _despesaRepository.List(descricao);
            var aux = result.OrderByDescending(x => x.Data).ToList();

            return _mapper.Map<List<DespesaResponse>>(aux);
        }

        public async Task<List<DespesaResponse>> GetListMes(int ano, int mes)
        {
            var result = await _despesaRepository.ListMes(ano, mes);
            var aux = result.OrderByDescending(x => x.Data).ToList();

            return _mapper.Map<List<DespesaResponse>>(aux);
        }

        public async Task<DespesaResponse> Update(DespesaRequest despesa, int id)
        {
            try
            {
                var oldDespesa = await _despesaRepository.Get(id);
                if (oldDespesa == null)
                    throw new ServiceException("Despesa não encontrada!");

                var entityDesc = await _despesaRepository.List(despesa.Descricao);
                if (entityDesc != default)
                {
                    var entityMes = await _despesaRepository.ListMes(despesa.Data.Year, despesa.Data.Month);
                    if (entityMes != default)
                        throw new DomainException("Não é possível existir duas despesas iguais no mesmo mês.");
                }

                var aux = _mapper.Map<Despesas>(despesa);
                aux.Id = id;
                aux.Validate();

                var a = await _despesaRepository.Update(aux);
                return _mapper.Map<DespesaResponse>(a);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na atualização da Despesa: {ex.Message}");
            }
        }

    }
}
