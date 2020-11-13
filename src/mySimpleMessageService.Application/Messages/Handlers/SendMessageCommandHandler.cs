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
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IContactService _contactService;
        private readonly IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IContactService contactRepository, IMessageRepository messageRepository)
        {
            _contactService = contactRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await _contactService.CheckIfExists(new HashSet<int>() { request.SenderId, request.RecipientId });
            var message = Message.Create(request.SenderId, request.MessageText, request.RecipientId);
            await _messageRepository.AddAsync(message);
            await _messageRepository.CompleteAsync();
            return Unit.Value;
        }
    }
}
