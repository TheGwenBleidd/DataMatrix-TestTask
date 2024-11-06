using AutoMapper;
using Contacts.Application.Abstractions;
using Contacts.Application.BusinessLogic.Contacts.Dtos;
using Contacts.Application.Helpers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Application.BusinessLogic.Contacts.Queries.GetById;

internal sealed class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetContactQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NotFoundException(nameof(request.Id), request.Id);
        return _mapper.Map<ContactDto>(contact);
    }
}