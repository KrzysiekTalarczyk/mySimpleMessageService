using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Contacts;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IMessageService _messageService;
        private readonly ContactService _contactService;
        public SendMessageCommandHandler(IMessageService messageService, ContactService contactRepository)
        {
            _messageService = messageService;
            _contactService = contactRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await _contactService.CheckIfExists(new HashSet<int>() {request.SenderId, request.RecipientId});
            
            var message = Message.Create(request.SenderId, MessageContent.Create(request.MessageText), request.RecipientId);
            await _messageService.SaveMessageAsync(message);
            return Unit.Value;
        }
    }
}
