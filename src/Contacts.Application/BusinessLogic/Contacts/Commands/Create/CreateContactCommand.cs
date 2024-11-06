using MediatR;

namespace Contacts.Application.BusinessLogic.Contacts.Commands.Create;

public sealed record CreateContactCommand(string GivenName, string Surname, string Email, string PhoneNumber) : IRequest<Guid>;