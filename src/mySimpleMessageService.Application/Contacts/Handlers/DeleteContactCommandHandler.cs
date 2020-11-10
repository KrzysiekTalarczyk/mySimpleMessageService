using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;


        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _contactRepository.GetAsync(request.Id);
            if (contact is null)
                throw new ContactNotFoundException(request.Id);
            await _contactRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
