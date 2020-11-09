using MediatR;

namespace mySimpleMessageService.Application.Messages.Command
{
    class DeleteMessageCommand : IRequest
    {
        public int MessageId { get; set; } //to guid
    }
}
