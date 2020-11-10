using System.Collections.Generic;
using MediatR;
using mySimpleMessageService.Application.Messages.Dtos;
using Sieve.Models;

namespace mySimpleMessageService.Application.Messages.Queries
{
   public class GetMessagesQuery : SieveModel, IRequest<IEnumerable<MessageDto>>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
