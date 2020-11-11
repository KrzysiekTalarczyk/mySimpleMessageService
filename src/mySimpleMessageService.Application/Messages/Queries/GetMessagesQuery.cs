using System.Collections.Generic;
using System.Linq;
using MediatR;
using mySimpleMessageService.Application.Messages.Dtos;
using Sieve.Models;

namespace mySimpleMessageService.Application.Messages.Queries
{
   public class GetMessagesQuery : SieveModel, IRequest<IQueryable<MessageDto>>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
