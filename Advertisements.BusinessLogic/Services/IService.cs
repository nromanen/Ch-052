using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
<<<<<<< HEAD
        T Create(T item);
=======
        void Create(T item);
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        void Update(T item);
        void Delete(int id);
    }

<<<<<<< HEAD
    //public interface ICategoryService : IService<CategoryDTO>
    //{
    //    void Create(CategoryDTO item);
    //    void Update(CategoryDTO item);
    //}

    //public interface IUserAwareService<T> : IService<T> where T : class
    //{
    //    IEnumerable<T> GetByUser(int userId);
    //}
=======
    public interface IUserAwareService<T> : IService<T> where T : class
    {
        IEnumerable<T> GetByUser(string userId);
    }

    public interface IFeedbackAwareService<T> : IService<T> where T : class
    {
        IEnumerable<T> GetByAdvertisement(int advertisementId);
    }

    public interface IUserService<T>   where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
}
