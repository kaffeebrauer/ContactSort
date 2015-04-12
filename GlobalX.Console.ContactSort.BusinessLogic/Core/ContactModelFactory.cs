using GlobalX.Console.ContactSort.BusinessLogic.Infrastructure;
using GlobalX.Console.ContactSort.Common.DataTransferObjects;
using GlobalX.Console.ContactSort.Common.Exceptions;

namespace GlobalX.Console.ContactSort.BusinessLogic.Core
{
    public class ContactModelFactory : ModelFactory<ContactSort.Common.Domain.Contact>
    {
        private readonly IMapperService _mapperService;

        public ContactModelFactory(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        public override ContactSort.Common.Domain.Contact Create(params object[] args)
        {
            var dto = args[0];
            if (dto.GetType() != typeof(ContactDataTransferObject))
            {
                throw new GlobalXException(ContactSort.Common.Resources.Exceptions.UNEXPECTED_TYPE);
            }

            var contact = _mapperService.Map<ContactDataTransferObject, ContactSort.Common.Domain.Contact>((ContactDataTransferObject)dto);
            return contact;
        }
    }
}
