namespace GlobalX.Console.ContactSort.Common.Domain.Events
{
    public interface IHandleEvents<T>
    {
        void Handle(T domainEvent);
    }
}
