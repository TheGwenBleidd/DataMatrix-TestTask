namespace Contacts.Application.BusinessLogic.Contacts.Dtos;

public sealed record ContactDto(Guid Id, string GivenName, string Surname, string Email, string PhoneNumber);