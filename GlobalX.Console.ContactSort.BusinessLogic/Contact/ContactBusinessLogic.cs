using System.Collections.Generic;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;

namespace GlobalX.Console.ContactSort.BusinessLogic.Contact
{
    public class ContactBusinessLogic : IContactBusinessLogic
    {
        public ContactBusinessLogic()
        {
            
        }

        public Common.Domain.Contact LoadContact(ContactDataTransferObject contact)
        {
            throw new System.NotImplementedException();
        }

        public IList<Common.Domain.Contact> ArrangeContact(IList<Common.Domain.Contact> contacts)
        {
            throw new System.NotImplementedException();
        }
    }
}
