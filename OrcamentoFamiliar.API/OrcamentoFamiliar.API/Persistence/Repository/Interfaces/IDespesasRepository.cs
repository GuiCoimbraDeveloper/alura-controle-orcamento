﻿using OrcamentoFamiliar.API.Entity;

namespace OrcamentoFamiliar.API.Persistence.Repository.Interfaces
{
    public interface IDespesasRepository : IBaseRepository<Despesas>
    {
        Task<List<Despesas>> ListMes(int ano, int mes); 
    }
}
