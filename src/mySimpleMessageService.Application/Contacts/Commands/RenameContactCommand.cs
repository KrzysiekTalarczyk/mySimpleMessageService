using MediatR;

namespace mySimpleMessageService.Application.Contacts.Commands
{
    class RenameContactCommand : IRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
