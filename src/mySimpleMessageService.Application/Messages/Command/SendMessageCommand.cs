using MediatR;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Messages.Command
{
    class SendMessageCommand : IRequest
    {
        public int SenderId { get; set; }
        public MessageContent MessageContent { get; set; }
        public int RecipientId { get; set; }
    }
}
