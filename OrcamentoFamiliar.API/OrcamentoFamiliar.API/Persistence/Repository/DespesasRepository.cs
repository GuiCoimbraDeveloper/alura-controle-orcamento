﻿using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using System.Linq.Expressions;

namespace OrcamentoFamiliar.API.Persistence.Repository
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly OrcamentoFamiliarDbContext _dataContext;
        public DespesasRepository(OrcamentoFamiliarDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(Despesas entity)
        {
            _dataContext.Despesas.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Despesas?> Get(int id)
        {
            return await _dataContext.Despesas.FindAsync(id);
        }

        public async Task Insert(Despesas entity)
        {
            _dataContext.Despesas.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Despesas>> List()
        {
            return await _dataContext.Despesas.ToListAsync();
        }

        public List<Despesas> List(Expression<Func<Despesas, bool>> expression)
        {
            return _dataContext.Despesas.Where(expression).ToList();
        }

        public async Task Update(Despesas entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
    }
}