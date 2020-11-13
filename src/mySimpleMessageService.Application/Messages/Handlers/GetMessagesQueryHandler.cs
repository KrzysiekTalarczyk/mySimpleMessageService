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
        private readonly IMessageRepository _messageRepository;

        public GetMessagesQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IQueryable<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var query = new ConversationRequest() { Contacts = new HashSet<int>() { request.SenderId, request.ReceiverId } };
            var messages = _messageRepository.GetMessagesBetweenContacts(query);
            return messages;
        }
    }
}
