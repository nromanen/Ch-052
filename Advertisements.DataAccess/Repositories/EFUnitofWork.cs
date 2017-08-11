using System;
using System.Data;
using System.Data.Entity;
using Advertisements.DataAccess.Context;
using Advertisements.DataAccess.Entities;

namespace Advertisements.DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ApplicationDbContext context;
        DbContextTransaction transaction;

        public DbContext Context { get { return this.context; } }

        public EFUnitOfWork() { this.context = new ApplicationDbContext(); }

        public IRepository<TEntity> GetRepo<TEntity>() where TEntity : class, IEntity
        {
            return new EFRepositoryBase<TEntity>(context);
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction == null)
            {
                if (this.transaction != null)
                    this.transaction.Dispose();

                this.transaction = this.context.Database.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
                this.transaction.Commit();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {

            }
            catch (Exception ex)
            {
                this.transaction.Rollback();
                throw ex;
            }
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
                this.transaction = null;
            }

            if (this.context != null)
            {
                this.context.Database.Connection.Close();
                this.context.Dispose();
                this.context = null;
            }
        }

        public void Rollback() { this.transaction.Rollback(); }
    }
}
