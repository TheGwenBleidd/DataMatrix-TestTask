using Contacts.Application.BusinessLogic.Contacts.Dtos;
using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Queries.GetById;

public sealed record GetContactQuery(Guid Id) : IRequest<ContactDto>;