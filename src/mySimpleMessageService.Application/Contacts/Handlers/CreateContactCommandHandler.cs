using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Contacts.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactRepository _contactRepository;


        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var existedContact = await _contactRepository.GetByNameAsync(request.Name);
            if (existedContact is { })
                throw new ContactExistException(request.Name);
            var contact = Contact.Create(request.Name);
            await _contactRepository.AddNewAsync(contact);
            await _contactRepository.CompleteAsync();
            return Unit.Value;
        }
    }
}
