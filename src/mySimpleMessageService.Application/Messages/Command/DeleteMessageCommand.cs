using MediatR;

namespace mySimpleMessageService.Application.Messages.Command
{
    public class DeleteMessageCommand : IRequest
    {
        public int MessageId { get; set; }
    }
}
