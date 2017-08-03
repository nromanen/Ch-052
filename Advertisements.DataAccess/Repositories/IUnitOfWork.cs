using Advertisements.DataAccess.Entities;
using System;
using System.Data;

namespace Advertisements.DataAccess.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<TEntity> GetRepo<TEntity>() where TEntity : class, IEntity;

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}
