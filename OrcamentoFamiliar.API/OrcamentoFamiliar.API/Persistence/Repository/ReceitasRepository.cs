using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace OrcamentoFamiliar.API.Persistence.Repository
{
    public class ReceitasRepository : IReceitasRepository
    {
        private readonly OrcamentoFamiliarDbContext _dataContext;
        public ReceitasRepository(OrcamentoFamiliarDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(Receitas entity)
        {
            _dataContext.Receitas.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Receitas> Get(int id)
        {
            return await _dataContext.Receitas.FindAsync(id);
        }

        public async Task Insert(Receitas entity)
        {
            _dataContext.Receitas.Add(entity);
            await _dataContext.SaveChangesAsync();
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

        public async Task Update(Receitas entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
    }
}
