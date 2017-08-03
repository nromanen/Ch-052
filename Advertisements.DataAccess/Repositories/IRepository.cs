using Advertisements.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
