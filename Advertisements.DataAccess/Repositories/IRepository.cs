using Advertisements.DataAccess.Entities;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

namespace Advertisements.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
<<<<<<< HEAD
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
=======
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        T Get(int id);
        T Get(int id, params Expression<Func<T, object>>[] includeExpressions);
        T Get(string id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(string id);
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    }
}
