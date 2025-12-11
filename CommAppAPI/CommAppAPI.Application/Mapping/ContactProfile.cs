using AutoMapper;
using CommAppAPI.Application.DTOs.Contact;
using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Mapping
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactCreateDto, Contact>()
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<ContactUpdateDto, Contact>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<Contact, ContactGetDto>();
        }
    }
}
