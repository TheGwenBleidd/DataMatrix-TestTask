using FluentValidation;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Delete;

public sealed class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required and cannot be an empty GUID.");
    }
}