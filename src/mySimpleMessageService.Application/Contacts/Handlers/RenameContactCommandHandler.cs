using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class RenameContactCommandHandler : IRequestHandler<RenameContactCommand>
    {
        private readonly IContactRepository _contactRepository;


        public RenameContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(RenameContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetAsync(request.Id);
            if (contact is null)
                throw new ContactNotFoundException(request.Id);
            contact.Name = request.Name;
            await _contactRepository.UpdateAsync(contact);
            return Unit.Value;
        }
    }
}
