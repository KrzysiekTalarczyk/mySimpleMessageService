using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IQueryable<MessageDto>>
    {
        private readonly MessageService _messageService;
        public GetMessagesQueryHandler(MessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IQueryable<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages =  _messageService.GetUsersMessages(new HashSet<int>() { request.SenderId, request.ReceiverId });
            return messages;
        }
    }
}
