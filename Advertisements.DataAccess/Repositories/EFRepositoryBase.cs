using Advertisements.DataAccess.Context;
using Advertisements.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
                item.IsDeleted = true;
        }

        public void Delete(string id)
        {
            var item = _context.Set<TEntity>().Find(id);
            if (item != null)
                item.IsDeleted = true;
        }

        public TEntity Get(int id)
        {
           return _context.Set<TEntity>().Find(id);
        }

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Where(r => r.IsDeleted != true).ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions
              .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
               (_context.Set<TEntity>().Where(r => r.IsDeleted != true), (current, expression) => current.Include(expression)).ToList();
        }

        public TEntity Get(
            int id,
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_context.Set<TEntity>().Where(r => r.IsDeleted != true), (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.Id == id);
            }

            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }


        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _context.Set<TEntity>().Where(filter).ToList();
        //}

        public IEnumerable<Advertisement> Find(string keyword,
            params Expression<Func<Advertisement, object>>[] includeExpressions)
        {
            string lowerKeyWord = keyword.ToLower();
            var isCategory = _context.Categories.Where((cat) => cat.Name.Equals(lowerKeyWord));
            bool exists = false;
            int catId = -1;
            foreach (var category in isCategory)
            {
                exists = true;
                catId = category.Id;
            }
            //catId = 2;
            if (exists)
            {                

                var inc = includeExpressions
               .Aggregate
                (_context.Advertisements.Where((adv) => adv.CategoryId == catId),
                (current, expression) => current.Include(expression));

                foreach (var a in inc)
                {

                }
                return inc;

                //_context.Advertisements.Where(adv => adv.Category.Name.Equals(lowerKeyWord)).AsEnumerable();
            }

            string tempKeyWord = char.ToUpper(keyword[0]) + keyword.Substring(1);
            //Types start from Uppercase letter
            var isType = _context.Types.Where((type) => type.Name.Equals(tempKeyWord));
            exists = false;
            foreach (var advType in isType)
                exists = true;

            if (exists)
            {
                return includeExpressions
               .Aggregate
                (_context.Advertisements.Where((adv) => adv.Type.Name.Equals(tempKeyWord)),
                (current, expression) => current.Include(expression));

                //return _context.Advertisements.Where((adv) => adv.Type.Name.Equals(tempKeyWord)).AsEnumerable();
            }


            var advsByDescription = includeExpressions
               .Aggregate
                (_context.Advertisements.Where((adv) => adv.Description.Contains(keyword)),
                (current, expression) => current.Include(expression));

            //var advsByDescription = _context.Advertisements.Where(r => r.Description.Contains(keyword));

            var advsByName = includeExpressions
              .Aggregate
               (_context.Advertisements.Where((adv) => adv.Title.Contains(keyword)),
               (current, expression) => current.Include(expression));

            //var advsByName = _context.Advertisements.Where((adv) => adv.Title.Contains(keyword));
            List<Advertisement> advsResult = new List<Advertisement>();

            foreach (var advert in advsByDescription)
            {
                advsResult.Add(advert);
            }
            foreach (var advert in advsByName)
            {
                if (!advsResult.Contains(advert))
                    advsResult.Add(advert);
            }

            return advsResult;
        }
    }
}
