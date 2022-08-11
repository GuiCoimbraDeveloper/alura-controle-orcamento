﻿using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Enum;
using OrcamentoFamiliar.API.Entity.Response;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using OrcamentoFamiliar.API.Services.Interfaces;
using System.Linq;
using System.Transactions;

namespace OrcamentoFamiliar.API.Services
{
    public class ResumoService : IResumoService
    {
        private readonly IDespesasRepository _despesasRepository;
        private readonly IReceitasRepository _receitasRepository;
        public ResumoService(IDespesasRepository despesasRepository, IReceitasRepository receitasRepository)
        {
            _despesasRepository = despesasRepository;
            _receitasRepository = receitasRepository;
        }
        public async Task<ResumoResponse> GetResumo(int ano, int mes)
        {
            var receitas = await _receitasRepository.ListMes(ano, mes);
            var despesas = await _despesasRepository.ListMes(ano, mes);

            var totalReceita = receitas.Sum(item => item.Valor);
            var totalDespesa = despesas.Sum(item => item.Valor);

            var response = new ResumoResponse()
            {
                DespesaMes = totalDespesa,
                ReceitasMes = totalReceita,
                Saldo = totalReceita - totalDespesa
            };

            var lista = despesas
                .GroupBy(t => t.Categoria, (key, x) =>
                {

                    return new
                    {
                        Category = key,
                        Quantidade = x.Sum(ta => ta.Valor),
                    };
                }).ToList();


            response.ValorGastoCategoria = lista
                .Select(a => new KeyValuePair<string, decimal>(Enum.GetName(a.Category), a.Quantidade))
                .ToList();

            return response;
        }
    }
}
