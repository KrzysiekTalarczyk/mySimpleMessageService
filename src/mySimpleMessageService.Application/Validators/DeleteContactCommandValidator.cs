using FluentValidation;
using mySimpleMessageService.Application.Contacts.Commands;

namespace mySimpleMessageService.Application.Validators
{
    class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
