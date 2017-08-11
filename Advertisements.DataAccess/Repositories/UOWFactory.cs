using Advertisements.DataAccess.Repositories;

namespace Advertisements.DataAccess.Services
{
    public class UOWFactory : IUOWFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new EFUnitOfWork();
        }
    }
}
