using AutoMapper;
using cogip.Models;
using CogipRestAPI.Domain.Models;

namespace CogipRestAPI.Api.AutoMapper
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactGetDto>()
                 .ForMember(c => c.companies, y => y.Ignore())
                 .ForMember(c => c.id, opt => opt.MapFrom(src => src.ContactId));
            CreateMap<ContactGetDto, Contact>()
                .ForMember(c => c.Companies, y => y.Ignore())
                .ForMember(c => c.ContactId, y => y.Ignore());
        }
    }
}
