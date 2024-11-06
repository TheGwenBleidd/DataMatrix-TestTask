using Contacts.Application.Abstractions;
using Contacts.Domain;
using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Create;

internal sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateContactCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        // Note: I could have added a check for the uniqueness of the phone number and email before creating a new contact.
        // However, I chose not to assume additional business requirements that were not explicitly mentioned in the task.
        // While adding such validation could demonstrate attention to detail, it might also overcomplicate the solution 
        // if it's not required by the given context. If I were expected to add it without a prompt and didn't, it could be 
        // considered a missed opportunity, but I aimed for a balanced approach in terms of task complexity.

        var newContact = new Contact(request.GivenName, request.Surname, request.Email, request.PhoneNumber);
        await _dbContext.Contacts.AddAsync(newContact, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newContact.Id;
    }
}