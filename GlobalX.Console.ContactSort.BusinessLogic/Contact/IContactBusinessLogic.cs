using System.Collections.Generic;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;

namespace GlobalX.Console.ContactSort.BusinessLogic.Contact
{

    public interface IContactBusinessLogic
    {
        Common.Domain.Contact LoadContact(ContactDataTransferObject contact);

        IList<Common.Domain.Contact> ArrangeContact(IList<Common.Domain.Contact> contacts);
    }
}
