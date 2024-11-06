using Contacts.Application.Abstractions;
using Contacts.Application.Helpers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Delete;

internal sealed class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteContactCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NotFoundException(nameof(request.Id), request.Id);
        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}