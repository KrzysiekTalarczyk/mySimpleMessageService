using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _contactRepository;


        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetAsync(request.Id);
            if (contact is null)
                throw new ContactNotFoundException(request.Id);
            contact.Name = request.Name;
            await _contactRepository.UpdateAsync();
            return Unit.Value;
        }
    }
}
