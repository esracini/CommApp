using AutoMapper;
using CommAppAPI.Application.DTOs.Contact;
using CommAppAPI.Application.Interfaces;
using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactReadRepository _read;
        private readonly IContactWriteRepository _write;
        private readonly IMapper _mapper;

        public ContactService(IContactReadRepository read,
                              IContactWriteRepository write,
                              IMapper mapper)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
        }

        public List<ContactGetDto> GetAll()
        {
            var contacts = _read.GetAll().ToList();
            return _mapper.Map<List<ContactGetDto>>(contacts);
        }

        public ContactGetDto GetById(int id)
        {
            var contact = _read.GetByIdAsync(id).Result;
            return _mapper.Map<ContactGetDto>(contact);
        }

        public ContactGetDto Add(ContactCreateDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);

            _write.AddAsync(contact).Wait();
            _write.SaveAsync().Wait();

            return _mapper.Map<ContactGetDto>(contact);
        }

        public ContactGetDto Update(int id, ContactUpdateDto dto)
        {
            var contact = _read.GetByIdAsync(id).Result;

            _mapper.Map(dto, contact);

            _write.Update(contact);
            _write.SaveAsync().Wait();

            return _mapper.Map<ContactGetDto>(contact);
        }

        public void Delete(int id)
        {
            var contact = _read.GetByIdAsync(id).Result;

            _write.Remove(contact);
            _write.SaveAsync().Wait();
        }
    }
}
