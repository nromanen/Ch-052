using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);  
    }

    public interface IUserService<T> : IService<T> where T : class
    {
        T Get(string id);
        void Delete(string id);
    }

    public interface IItemService<T> : IService<T> where T : class
    {
        T Get(int id);
        void Delete(int id);
        bool IsValid(T item);
    }

    public interface IAdvertisementService<T> : IItemService<T>where T : class
    {
        IEnumerable<T> GetByUser(string userId);
        IEnumerable<T> Find(string keyword);
    }

    public interface IFeedbackService<T> : IItemService<T> where T : class 
    {
        IEnumerable<T> GetByAdvertisement(int advertisementId);
        bool AlreadyCommented(string id, int advId);
    }

}
