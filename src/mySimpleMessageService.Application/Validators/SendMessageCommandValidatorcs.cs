using FluentValidation;
using mySimpleMessageService.Application.Messages.Command;

namespace mySimpleMessageService.Application.Validators
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty();
            RuleFor(x => x.SenderId).NotEmpty();
            RuleFor(x => x.RecipientId).NotEmpty(); 
        }
    }
}
