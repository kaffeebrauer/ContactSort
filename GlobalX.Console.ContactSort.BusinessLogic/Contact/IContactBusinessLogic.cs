using System.Collections.Generic;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;

namespace GlobalX.Console.ContactSort.BusinessLogic.Contact
{

    public interface IContactBusinessLogic
    {
        Common.Domain.Contact LoadContact(ContactDataTransferObject contact);

        IList<ContactDataTransferObject> ArrangeContact(IList<ContactDataTransferObject> contacts);
    }
}
