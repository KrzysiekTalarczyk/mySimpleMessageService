using FluentValidation;
using mySimpleMessageService.Application.Contacts.Commands;

namespace mySimpleMessageService.Application.Contacts.Validators
{
   public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).MaximumLength(30);
        }
    }
}
