using MediatR;

namespace mySimpleMessageService.Application.Contacts.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
