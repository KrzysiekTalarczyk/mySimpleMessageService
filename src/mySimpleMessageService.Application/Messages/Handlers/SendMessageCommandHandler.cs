using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IMessageService _messageService;
        private readonly IContactRepository _contactRepository;
        public SendMessageCommandHandler(IMessageService messageService, IContactRepository contactRepository)
        {
            _messageService = messageService;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var sender = await _contactRepository.GetAsync(request.SenderId);
            var recipient = await _contactRepository.GetAsync(request.RecipientId);

            var message = Message.Create(sender.Id, request.MessageContent, recipient.Id);
            await _messageService.SaveMessageAsync(message);
            return Unit.Value;
        }
    }
}
