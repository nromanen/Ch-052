using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.BusinessLogic.Mapper;
using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Repositories;
using Advertisements.DTO.Models;
using System.Linq.Expressions;

namespace Advertisements.BusinessLogic.Services
{    

    public interface IMyService<TSource, TTarget> where TSource:class where TTarget: class
    { 
        IEnumerable<TTarget> GetAll(params Expression<Func<TSource, object>>[] includeExpressions);
        TTarget Get(int id, params Expression<Func<TSource, object>>[] includeExpressions);
        TTarget Get(string id, params Expression<Func<TSource, object>>[] includeExpressions);
        void Create(TTarget item);
        void Update(TTarget item);
        void Delete(int id);
        void Delete(string id);
        MyBaseMapper _mapper { get; set; }
    }

    public interface IUserAwareService<T> where T : class
    {
        IEnumerable<T> GetByUser(string userId);
    }

    public interface IAdvertisementAwareService<T> where T : class
    {
        IEnumerable<T> Find(string keyword);
        IEnumerable<T> Get(int page, int pageSize);
        int GetCount();
    }

    public interface IFeedbackAwareService<T> where T : class
    {
        IEnumerable<T> GetByAdvertisement(int advertisementId);
        bool AlreadyCommented(string id, int advId);
    }

    public interface IUserService<T>   where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }

}
