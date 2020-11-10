using MediatR;

namespace mySimpleMessageService.Application.Contacts.Commands
{
    public class CreateContactCommand : IRequest
    {
        public string Name { get; set; }
    }
}
