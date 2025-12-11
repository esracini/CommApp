using AutoMapper;
using CommAppAPI.Application.DTOs.Person;
using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Mapping
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonGetDto>();//Personel tablosu tüm kayıtlar (sade)

            CreateMap<Person, PersonGetWithRelationsDto>() //ilişkili tüm kayıtlar
               .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
               .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts));

            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}
