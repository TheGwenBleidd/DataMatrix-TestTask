using Contacts.Application.BusinessLogic.Contacts.Dtos;
using Contacts.Application.Helpers.Pagination;
using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Queries.GetPaginated;

public sealed record GetContactsPaginatedQuery : PaginatedQuery, IRequest<PaginatedList<ContactDto>>;