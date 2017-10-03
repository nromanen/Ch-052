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
    public class MyService<TSource,TTarget>: IMyService<TSource, TTarget> where TSource: class,IEntity where TTarget: class, IDTO
    {
        private IUOWFactory _factory;
        public MyBaseMapper _mapper { get; set; }
        public MyService(IUOWFactory factory)
        {
            _factory = factory;
        }            

        public void Create(TTarget item)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                var entity = _mapper.Map(item);
                repository.Create(entity as TSource);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                repository.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(string id)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                repository.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }                 

        public void Update(TTarget item)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                var entity = _mapper.Map(item);
                repository.Update(entity as TSource);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        TTarget IMyService<TSource, TTarget>.Get(int id, params Expression<Func<TSource, object>>[] includeExpressions)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                var entity = repository.Get(id, includeExpressions);
                return _mapper.Map(entity) as TTarget;
            }
        }

        TTarget IMyService<TSource, TTarget>.Get(string id, params Expression<Func<TSource, object>>[] includeExpressions)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                var entity = repository.Get(id);                
                return _mapper.Map(entity) as TTarget;
            }
        }

        IEnumerable<TTarget> IMyService<TSource, TTarget>.GetAll(params Expression<Func<TSource, object>>[] includeExpressions)
        {
            using (var uow = _factory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<TSource>();
                var entities = repository.GetAll(includeExpressions);

                var tempList = _mapper.MapCollection(entities);
                List<TTarget> targetList = new List<TTarget>();

                foreach (var element in tempList)
                {
                    targetList.Add(element as TTarget);
                }

                return targetList;
            }
        }
    }

}
