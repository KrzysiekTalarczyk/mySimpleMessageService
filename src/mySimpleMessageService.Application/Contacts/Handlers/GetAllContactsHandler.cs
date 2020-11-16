using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Contacts.Queries;
using mySimpleMessageService.Application.Filtering;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, FilteredResponse<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IQueryFrameExecutor _queryFrameExecutor;

        public GetAllContactsHandler(IContactRepository contactRepository, IQueryFrameExecutor queryFrameExecutor)
        {
            _contactRepository = contactRepository;
            _queryFrameExecutor = queryFrameExecutor;
        }

        public async Task<FilteredResponse<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = _contactRepository.GetAllAsync();
            var filteredResults = _queryFrameExecutor.SelectData(contacts, request, out var totalResultCount);
            var contactsDto = filteredResults.Select(c => new ContactDto(c));
            return await Task.FromResult(new FilteredResponse<ContactDto>(contactsDto, totalResultCount));
        }
    }
}
