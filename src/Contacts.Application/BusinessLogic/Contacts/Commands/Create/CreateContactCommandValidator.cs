using FluentValidation;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Create;

// The task description did not specify requirements for input parameter validation rules.
// I decided to add basic validation logic to ensure data correctness and minimize input errors.
public sealed class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.GivenName)
            .NotEmpty().WithMessage("Given Name is required.")
            .MaximumLength(50).WithMessage("Given Name must not exceed 50 characters.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .MaximumLength(50).WithMessage("Surname must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone Number must be a valid number with 10 to 15 digits, optionally prefixed with +.");
    }
}