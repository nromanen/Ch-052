using Advertisements.DataAccess.Context;
using Advertisements.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace Advertisements.DataAccess.Repositories
{
    public class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        AdvertisementsContext _context;

        public EFRepositoryBase(AdvertisementsContext context)
        {
            _context = context;
        }

        public void Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            if (item != null)
                _context.Set<TEntity>().Remove(item);
        }

        public TEntity Get(int id)
        {
           return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _context.Set<TEntity>().Where(filter).ToList();
        //}
    }
}
