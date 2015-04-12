namespace GlobalX.Console.ContactSort.Common.Domain.Events
{
    public interface IHandle<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent domainEvent);
    }
}
