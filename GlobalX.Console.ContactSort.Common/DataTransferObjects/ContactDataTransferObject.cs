namespace GlobalX.Console.ContactSort.Common.DataTransferObjects
{
    public class ContactDataTransferObject
    {
        public ContactDataTransferObject(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
