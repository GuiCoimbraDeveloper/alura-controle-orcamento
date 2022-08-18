using System.Linq.Expressions;

namespace OrcamentoFamiliar.API.Persistence.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> Get(int id);
        Task<List<T>> List(string? descricao);
        Task<List<T>> List(Expression<Func<T, bool>> expression);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
