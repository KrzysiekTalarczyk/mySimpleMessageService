using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IEnumerable<MessageDto>>
    {
        private readonly IMessageService _messageService;
        public GetMessagesQueryHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetUsersMessages(new int[] { request.SenderId, request.ReceiverId });
            return messages;
        }
    }
}
