using MediatR;

namespace mySimpleMessageService.Application.Contacts.Commands
{
    public class UpdateContactCommand : IRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
