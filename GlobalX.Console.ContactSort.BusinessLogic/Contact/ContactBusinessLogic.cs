using System.Collections.Generic;
using System.Linq;
using GlobalX.Console.ContactSort.BusinessLogic.Core;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;

namespace GlobalX.Console.ContactSort.BusinessLogic.Contact
{
    public class ContactBusinessLogic : IContactBusinessLogic
    {
        private readonly ContactModelFactory _contactModelFactory;
        public ContactBusinessLogic(ContactModelFactory contactModelFactory)
        {
            _contactModelFactory = contactModelFactory;
        }

        public Common.Domain.Contact LoadContact(ContactDataTransferObject contactDto)
        {
            var contact = _contactModelFactory.Create(contactDto);
            return contact;
        }

        public IList<ContactDataTransferObject> ArrangeContact(IList<ContactDataTransferObject> contacts)
        {
            return contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }
    }
}
