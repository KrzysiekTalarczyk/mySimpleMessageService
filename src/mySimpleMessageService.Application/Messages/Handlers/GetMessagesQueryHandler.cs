using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Filtering;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, FilteredResponse<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IQueryFrameExecutor _queryFrameExecutor;

        public GetMessagesQueryHandler(IMessageRepository messageRepository, IQueryFrameExecutor queryFrameExecutor)
        {
            _messageRepository = messageRepository;
            _queryFrameExecutor = queryFrameExecutor;
        }

        public Task<FilteredResponse<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var query = new ConversationRequest() { Contacts = new HashSet<int>() { request.SenderId, request.ReceiverId } };
            var messages = _messageRepository.GetMessagesBetweenContacts(query);
            var filteredResults = _queryFrameExecutor.SelectData(messages, request, out var totalResultCount);
            var messagesDto = filteredResults.Select(c => new MessageDto(c));
            return Task.FromResult(new FilteredResponse<MessageDto>(messagesDto, totalResultCount));
        }
    }
}
