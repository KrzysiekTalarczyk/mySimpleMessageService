using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;


        public UpdateContactCommandHandler(IContactRepository contactRepository, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetContactAsync(request.Id);
            contact.Name = request.Name;
            await _contactRepository.CompleteAsync();
            return Unit.Value;
        }
    }
}
