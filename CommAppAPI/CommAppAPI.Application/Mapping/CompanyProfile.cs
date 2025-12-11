using AutoMapper;
using CommAppAPI.Application.DTOs.Company;
using CommAppAPI.Domain.Entities;

namespace CommAppAPI.Application.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            //bir sınıfı başka bir sınıfa dönüştür.
            CreateMap<Company, CompanyGetDto>(); //Entity -> DTO (Get)

            CreateMap<CompanyCreateDto, Company>(); //DTO-> Entity (Post)
            CreateMap<CompanyUpdateDto, Company>(); //DTO-> Entity (Put)
            CreateMap<Company, CompanyGetDetailDto>();
        }
    }
}
