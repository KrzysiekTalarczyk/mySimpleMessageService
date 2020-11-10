using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Contacts.Queries;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactsHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts =  _contactRepository.GetAllAsync().ToList();
            return contacts;
        }
    }
}
