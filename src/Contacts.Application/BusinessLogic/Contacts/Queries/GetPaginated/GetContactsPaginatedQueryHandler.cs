using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contacts.Application.Abstractions;
using Contacts.Application.BusinessLogic.Contacts.Dtos;
using Contacts.Application.Helpers.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Application.BusinessLogic.Contacts.Queries.GetPaginated;

internal sealed class GetContactsPaginatedQueryHandler : IRequestHandler<GetContactsPaginatedQuery, PaginatedList<ContactDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetContactsPaginatedQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ContactDto>> Handle(GetContactsPaginatedQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Contacts
                         .AsNoTracking()
                         .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                         .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}