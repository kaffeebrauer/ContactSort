using GlobalX.Console.ContactSort.BusinessLogic.Infrastructure;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Domain.Events;
using GlobalX.Console.ContactSort.Common.Exceptions;

namespace GlobalX.Console.ContactSort.BusinessLogic.Core
{
    public class ContactModelFactory : ModelFactory<Common.Domain.Contact>
    {
        private readonly IMapperService _mapperService;
        private readonly IEventBroker _eventBroker;

        public ContactModelFactory()
        {
            
        }

        public ContactModelFactory(IMapperService mapperService, IEventBroker eventBroker)
        {
            _mapperService = mapperService;
            _eventBroker = eventBroker;
        }

        public override Common.Domain.Contact Create(params object[] args)
        {
            var dto = args[0];
            if (dto.GetType() != typeof(ContactDataTransferObject))
            {
                throw new GlobalXException(Common.Resources.Exceptions.UNEXPECTED_TYPE);
            }

            var contact = _mapperService.Map<ContactDataTransferObject, Common.Domain.Contact>((ContactDataTransferObject)dto);
            _eventBroker.Raise(new ContactRegisteredEvent(contact));
            return contact;
        }
    }
}
