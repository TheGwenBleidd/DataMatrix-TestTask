using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Update;

public sealed record UpdateContactCommand(Guid Id, string GivenName, string Surname, string Email, string PhoneNumber) : IRequest<Unit>;