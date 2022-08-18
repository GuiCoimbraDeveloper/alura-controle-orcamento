using Microsoft.EntityFrameworkCore;
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

        public async Task<Despesas> Delete(Despesas entity)
        {
            _dataContext.Despesas.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Despesas?> Get(int id)
        {
            return await _dataContext.Despesas.FindAsync(id);
        }

        public async Task<Despesas> Insert(Despesas entity)
        {
            _dataContext.Despesas.Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Despesas>> List(string? descricao)
        {
            return await _dataContext.Despesas.ToListAsync();
        }

        public async Task<List<Despesas>> List(Expression<Func<Despesas, bool>> expression)
        {
            return await _dataContext.Despesas.Where(expression).ToListAsync();
        }

        public async Task<List<Despesas>> ListMes(int ano, int mes)
        {
            return await _dataContext.Despesas.Where(x => x.Data.Year == ano && x.Data.Month == mes).ToListAsync();
        }

        public async Task<Despesas> Update(Despesas entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
