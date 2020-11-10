using MediatR;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Messages.Command
{
    public class SendMessageCommand : IRequest
    {
        public int SenderId { get; set; }
        public string MessageText { get; set; }
        public int RecipientId { get; set; }
    }
}
