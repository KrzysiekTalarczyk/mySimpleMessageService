using FluentValidation;
using mySimpleMessageService.Application.Messages.Command;

namespace mySimpleMessageService.Application.Messages.Validators
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator()
        {
            RuleFor(x => x.MessageText).NotEmpty().MinimumLength(1).MaximumLength(300);
            RuleFor(x => x.SenderId).NotEmpty();
            RuleFor(x => x.RecipientId).NotEmpty(); 
        }
    }
}
