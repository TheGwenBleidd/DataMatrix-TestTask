using Contacts.Application.Abstractions;
using Contacts.Application.Helpers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Update;

internal sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateContactCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NotFoundException(nameof(request.Id), request.Id);
        contact.Update(request.GivenName, request.Surname, request.Email, request.PhoneNumber);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}