using System.Collections.Generic;
using System.Linq;
using GlobalX.Console.ContactSort.BusinessLogic.Contact;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Domain;

namespace GlobalX.Console.ContactSort.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactBusinessLogic _contactBusinessLogic;

        public ContactService(
            IContactBusinessLogic contactBusinessLogic
            )
        {
            _contactBusinessLogic = contactBusinessLogic;
        }

        public ContactDataTransferObject LoadRawContact(string content)
        {
            var firstName = content.Split(',')[1].Trim();
            var lastName = content.Split(',')[0].Trim();
            var dto = new ContactDataTransferObject(firstName, lastName);
            return dto;
        }

        public Contact LoadContact(ContactDataTransferObject contactDto)
        {
            return _contactBusinessLogic.LoadContact(contactDto);
        }

        public IList<ContactDataTransferObject> ArrangeContact(List<ContactDataTransferObject> contacts)
        {
            return _contactBusinessLogic.ArrangeContact(contacts.ToList()); 
        }
        
    }
}
