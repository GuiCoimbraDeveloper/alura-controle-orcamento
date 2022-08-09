﻿using System.Linq.Expressions;

namespace OrcamentoFamiliar.API.Persistence.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> Get(int id);
        Task<List<T>> List();
        List<T> List(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
