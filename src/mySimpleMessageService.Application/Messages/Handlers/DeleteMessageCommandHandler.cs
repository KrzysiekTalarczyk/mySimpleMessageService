using System.Threading;
using System.Threading.Tasks;
using MediatR;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Command;

namespace mySimpleMessageService.Application.Messages.Handlers
{
    class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public DeleteMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetAsync(request.MessageId);
            if (message is null)
                throw new MessageNoFoundException(request.MessageId);
            await _messageRepository.RemoveAsync(message);
            return Unit.Value;
        }
    }
}
