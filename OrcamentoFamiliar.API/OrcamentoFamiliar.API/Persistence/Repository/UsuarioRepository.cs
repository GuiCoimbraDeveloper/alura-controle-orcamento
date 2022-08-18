using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Persistence.Repository.Interfaces;
using System.Linq.Expressions;

namespace OrcamentoFamiliar.API.Persistence.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OrcamentoFamiliarDbContext _dataContext;
        public UsuarioRepository(OrcamentoFamiliarDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Usuario?> Auth(string user, string password)
        {
            var usuario = await _dataContext.User.FirstOrDefaultAsync(x => x.Username == user && x.Password == password);

            return usuario;
        }

        public Task<Usuario> Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> List(string? descricao)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> List(Expression<Func<Usuario, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
