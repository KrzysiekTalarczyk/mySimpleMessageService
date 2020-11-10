using FluentValidation;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Application.Messages.Validators
{
    public class GetMessagesQueryValidator : AbstractValidator<GetMessagesQuery>
    {
        public GetMessagesQueryValidator()
        {
            RuleFor(x => x.SenderId).NotEmpty();
            RuleFor(x => x.ReceiverId).NotEmpty();
        }
    }
}
