using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Contacts.Application.Helpers.Behaviors;

public class ValidationBehavior<TRequest, TResponce>
    : IPipelineBehavior<TRequest, TResponce> where TRequest : IRequest<TResponce>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next();
    }
}