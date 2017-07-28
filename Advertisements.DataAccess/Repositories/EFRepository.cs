using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Advertisements.DataAccess.Entities;

namespace Advertisements.DataAccess.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity>
         where TEntity : class, IEntity
    {
        readonly EFUnitOfWork unitOfWork;

        public EFRepository(EFUnitOfWork unitOfWork) { this.unitOfWork = unitOfWork; }

        public void Create(TEntity item)
        {
            this.unitOfWork.BeginTransaction();

            this.unitOfWork.Context.Set<TEntity>().Add(item);
        }

        public void Delete(int id)
        {
            this.unitOfWork.BeginTransaction();

            TEntity entity = unitOfWork.Context.Set<TEntity>().Find(id);

            if (entity != null)
                this.unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(int id)
        {
            return this.unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.unitOfWork.Context.Set<TEntity>().ToList();
        }

        public void Update(TEntity item)
        {
            this.unitOfWork.BeginTransaction();

            unitOfWork.Context.Entry(item).State = EntityState.Modified;
        }
    }
}
