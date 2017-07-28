using System;
using System.Data;
using System.Data.Entity;
using Advertisements.DataAccess.Context;

namespace Advertisements.DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        DbContext context;
        DbContextTransaction transaction;

        public DbContext Context { get { return this.context; } }

        public EFUnitOfWork() { this.context = new AdvertisementsContext(); }

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
            catch
            {
                this.transaction.Rollback();
                throw new Exception();
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
