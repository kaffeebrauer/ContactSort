using GlobalX.Console.ContactSort.Common.Console;

namespace GlobalX.Console.ContactSort.Common.Domain.Events
{
    public class ContactRegisteredEvent : IDomainEvent
    {
        private readonly IOutputWriter _outputWriter;

        public ContactRegisteredEvent(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }
        private readonly Contact _contact;
        public ContactRegisteredEvent(Contact contact)
        {
 
            _contact = contact;
            System.Console.WriteLine(string.Format("{0}, {1}", _contact.LastName, _contact.FirstName));
        }
    }
}
