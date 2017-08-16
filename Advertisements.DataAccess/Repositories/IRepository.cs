using Advertisements.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advertisements.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        T Get(int id);
        T Get(int id, params Expression<Func<T, object>>[] includeExpressions);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
