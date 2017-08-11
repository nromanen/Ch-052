using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    //public interface ICategoryService : IService<CategoryDTO>
    //{
    //    void Create(CategoryDTO item);
    //    void Update(CategoryDTO item);
    //}

    public interface IUserAwareService<T> : IService<T> where T : class
    {
        IEnumerable<T> GetByUser(string userId);
    }
}
