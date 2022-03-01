using AutoMapper;
using cogip.Models;
using CogipRestAPI.Domain.Models;

namespace CogipRestAPI.Api.AutoMapper
{
    public class CompanyMappingProfiles : Profile
    {
        public CompanyMappingProfiles()
        {
            CreateMap<Company, CompanyGetDto>();
            CreateMap<Company, CompanyPostDto>();
        }
    }
}
