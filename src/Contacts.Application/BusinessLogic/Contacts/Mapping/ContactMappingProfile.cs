using AutoMapper;
using Contacts.Application.BusinessLogic.Contacts.Dtos;
using Contacts.Domain;

namespace Contacts.Application.BusinessLogic.Contacts.Mapping;

public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        CreateMap<Contact, ContactDto>();
    }
}
