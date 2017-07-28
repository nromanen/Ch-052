using System.Data;

namespace Advertisements.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
    }
}
