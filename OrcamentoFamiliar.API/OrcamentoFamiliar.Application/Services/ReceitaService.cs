using OrcamentoFamiliar.Application.Services.Interfaces;
using OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.Domain.Entity.Response;
using OrcamentoFamiliar.Domain.Entity.Request;
using AutoMapper;
using OrcamentoFamiliar.Application.Handlers;
using OrcamentoFamiliar.Domain.Entity;

namespace OrcamentoFamiliar.Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitasRepository _receitaRepository;
        private readonly IMapper _mapper;
        public ReceitaService(IReceitasRepository receitaRepository, IMapper mapper)
        {
            _receitaRepository = receitaRepository;
            _mapper = mapper;
        }

        public async Task<ReceitaResponse> Create(ReceitaRequest receita)
        {
            try
            {
                var entityDesc = await _receitaRepository.List(receita.Descricao);
                if (entityDesc != default)
                {
                    var entityMes = await _receitaRepository.ListMes(receita.Data.Year, receita.Data.Month);
                    if (entityMes != default)
                        throw new DomainException("Não é possível existir duas despesas iguais no mesmo mês.");
                }

                var aux = _mapper.Map<Receitas>(receita);
                aux.Validate();

                var receitaCreated =  await _receitaRepository.Insert(aux);

                return _mapper.Map<ReceitaResponse>(receitaCreated);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar receita", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var receita = await _receitaRepository.Get(id);
                if (receita is null)
                    throw new ServiceException("Nenhuma Receita encontrada para remoção");

                await _receitaRepository.Delete(receita);
            }
            catch (Exception)
            {
                throw new Exception("Erro na exclusão da Receita!");
            }
        }

        public async Task<ReceitaResponse> GetById(int id)
        {
                var result = await _receitaRepository.Get(id);
            if (result is null)
                throw new ServiceException("Nenhuma Receita encontrada.");

            return _mapper.Map<ReceitaResponse>(result);
        }

        public async Task<List<ReceitaResponse>> GetList(string? descricao)
        {

            if (string.IsNullOrEmpty(descricao))
                descricao = "";

            var result = await _receitaRepository.List(descricao);
            var aux = result.OrderByDescending(x => x.Data);

            return _mapper.Map<List<ReceitaResponse>>(aux); ;

        }

        public async Task<List<ReceitaResponse>> GetListMes(int ano, int mes)
        {

            var result = await _receitaRepository.ListMes(ano, mes);
            var aux = result.OrderByDescending(x => x.Data);

            return _mapper.Map<List<ReceitaResponse>>(aux);
        }

        public async Task<ReceitaResponse> Update(ReceitaRequest receita,int id)
        {
            try
            {
                var oldReceita = await _receitaRepository.Get(id);
                if (oldReceita == null)
                    throw new ServiceException("Receita não encontrada!");

                var entityDesc = await _receitaRepository.List(receita.Descricao);
                if (entityDesc != default)
                {
                    var entityMes = await _receitaRepository.ListMes(receita.Data.Year, receita.Data.Month);
                    if (entityMes != default)
                        throw new DomainException("Não é possível existir duas Receitas iguais no mesmo mês.");
                }

                var aux = _mapper.Map<Receitas>(receita);
                aux.Id = id;
                aux.Validate();

                var a = await _receitaRepository.Update(aux);
                return _mapper.Map<ReceitaResponse>(a);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na atualização da Receita: {ex.Message}");
            }
        }

    }
}
