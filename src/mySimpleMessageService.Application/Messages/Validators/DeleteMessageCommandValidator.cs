using FluentValidation;
using mySimpleMessageService.Application.Messages.Command;

namespace mySimpleMessageService.Application.Messages.Validators
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator()
        {
            RuleFor(x => x.MessageId).NotEmpty();
        }
    }
}
