using FluentValidation;

namespace Contacts.Application.BusinessLogic.Contacts.Queries.GetById;

public sealed class GetContactQueryValidator : AbstractValidator<GetContactQuery>
{
    public GetContactQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required and cannot be an empty GUID.");
    }
}