namespace LeaveManagementSystem.Framework
{
    public interface IAggregateRoot
    {

    }
    public interface IApplicationService
    {

    }
    public interface IRepository<T, TKey> where T: IAggregateRoot
    {
        T GetById(TKey id);
        void Create(T item);

    }
}