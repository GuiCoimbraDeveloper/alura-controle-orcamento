using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.Domain.Entity;
using OrcamentoFamiliar.Infra.Persistence.Repository.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace OrcamentoFamiliar.Infra.Persistence.Repository
{
    public class ReceitasRepository : IReceitasRepository
    {
        private readonly OrcamentoFamiliarDbContext _dataContext;
        public ReceitasRepository(OrcamentoFamiliarDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Receitas> Delete(Receitas entity)
        {
            _dataContext.Receitas.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Receitas?> Get(int id)
        {
            return await _dataContext.Receitas.FindAsync(id);
        }

        public async Task<Receitas> Insert(Receitas entity)
        {
            _dataContext.Receitas.Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Receitas>> List(string descricao)
        {
            return await _dataContext.Receitas.Where(x => x.Descricao.Contains(descricao)).ToListAsync();
        }

        public async Task<List<Receitas>> ListMes(int ano, int mes)
        {
            return await _dataContext.Receitas.Where(x => x.Data.Year == ano && x.Data.Month == mes).ToListAsync();
        }

        public async Task<List<Receitas>> List(Expression<Func<Receitas, bool>> expression)
        {
            return await _dataContext.Set<Receitas>().Where(expression).ToListAsync();
        }

        public async Task<Receitas> Update(Receitas entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
