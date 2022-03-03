using AutoMapper;
using cogip.Models;
using CogipRestAPI.Domain.Models;

namespace CogipRestAPI.Api.AutoMapper
{
    public class CompanyMappingProfiles : Profile
    {
        public CompanyMappingProfiles()
        {
            CreateMap<Company, CompanyGetDto>()
                .ForMember(c => c.Contacts, y => y.Ignore())
                .ForMember(c => c.id, opt => opt.MapFrom(src => src.CompanyId));
            CreateMap<CompanyPostPutDto, Company>()
                .ForMember(c => c.Contacts, y => y.Ignore())
                .ForMember(c => c.CompanyId, y => y.Ignore());
        }
    }
}
