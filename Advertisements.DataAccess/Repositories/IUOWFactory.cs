namespace Advertisements.DataAccess.Repositories
{
    public interface IUOWFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
