using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
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
            await _contactRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
