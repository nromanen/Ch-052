using Advertisements.DataAccess.Context;
using Advertisements.DataAccess.Entities;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
=======
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

namespace Advertisements.DataAccess.Repositories
{
    public class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        ApplicationDbContext _context;

        public EFRepositoryBase(ApplicationDbContext context)
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

<<<<<<< HEAD
=======
        public void Delete(string id)
        {
            var item = _context.Set<TEntity>().Find(id);
            if (item != null)
                _context.Set<TEntity>().Remove(item);
        }

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        public TEntity Get(int id)
        {
           return _context.Set<TEntity>().Find(id);
        }

<<<<<<< HEAD
=======
        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

<<<<<<< HEAD
=======
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions
              .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
               (_context.Set<TEntity>(), (current, expression) => current.Include(expression)).ToList();
        }

        public TEntity Get(
            int id,
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_context.Set<TEntity>(), (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.Id == id);
            }

            return _context.Set<TEntity>().Find(id);
        }

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        public void Update(TEntity item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

<<<<<<< HEAD
=======

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _context.Set<TEntity>().Where(filter).ToList();
        //}
    }
}
