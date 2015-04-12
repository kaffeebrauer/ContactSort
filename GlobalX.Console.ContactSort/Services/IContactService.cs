using System.Collections.Generic;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Domain;

namespace GlobalX.Console.ContactSort.Services
{
    public interface IContactService
    {
        ContactDataTransferObject LoadRawContact(string content);

        IList<ContactDataTransferObject> ArrangeContact(List<ContactDataTransferObject> contacts);

        Contact LoadContact(ContactDataTransferObject rawContact);

    }
}
