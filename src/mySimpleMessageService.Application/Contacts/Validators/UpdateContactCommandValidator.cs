using FluentValidation;
using mySimpleMessageService.Application.Contacts.Commands;

namespace mySimpleMessageService.Application.Contacts.Validators
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).MaximumLength(30);
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
