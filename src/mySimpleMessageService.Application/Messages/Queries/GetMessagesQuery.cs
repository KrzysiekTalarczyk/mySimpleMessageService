using System.Collections.Generic;
using MediatR;
using mySimpleMessageService.Application.Messages.Dtos;

namespace mySimpleMessageService.Application.Messages.Queries
{
   public class GetMessagesQuery : IRequest<IEnumerable<MessageDto>>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
