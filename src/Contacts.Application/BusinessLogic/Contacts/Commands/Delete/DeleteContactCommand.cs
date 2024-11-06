using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Delete;

public sealed record DeleteContactCommand(Guid Id) : IRequest<Unit>;