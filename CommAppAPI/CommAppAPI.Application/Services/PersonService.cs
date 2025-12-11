using AutoMapper;
using CommAppAPI.Application.DTOs.Person;
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
    public class PersonService : IPersonService
    {
        private readonly IPersonReadRepository _read;
        private readonly IPersonWriteRepository _write;
        private readonly IMapper _mapper;

        public PersonService(IPersonReadRepository read,
                             IPersonWriteRepository write,
                             IMapper mapper)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
        }

        public List<PersonGetDto> GetAll()
        {
            var persons = _read.GetAll().ToList();
            return _mapper.Map<List<PersonGetDto>>(persons);
        }

        public List<PersonGetWithRelationsDto> GetAllWithRelations()
        {
            var persons = _read.GetAllPersonsWithRelations().ToList();
            return _mapper.Map<List<PersonGetWithRelationsDto>>(persons);
        }

        public PersonGetDto GetById(int id)
        {
            var person = _read.GetByIdAsync(id).Result;
            return _mapper.Map<PersonGetDto>(person);
        }

        public PersonGetDto Add(PersonCreateDto dto)
        {
            var person = _mapper.Map<Person>(dto);

            _write.AddAsync(person).Wait();
            _write.SaveAsync().Wait();

            return _mapper.Map<PersonGetDto>(person);
        }

        public PersonGetDto Update(int id, PersonUpdateDto dto)
        {
            var person = _read.GetPersonWithRelations(id); // Tracking'li gelecek

            if (person == null)
                throw new Exception("Person bulunamadı");

            // Kişisel bilgiler
            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.CompanyId = dto.CompanyId;

            // İletişim bilgilerini sıfırla
            person.Contacts.Clear();

            foreach (var c in dto.Contacts)
            {
                person.Contacts.Add(new Contact
                {
                    Id = c.Id,
                    PersonId = id,
                    Type = c.Type,
                    Value = c.Value
                });
            }

            _write.Update(person);
            _write.SaveAsync().Wait();

            return _mapper.Map<PersonGetDto>(person);
        }

        public void Delete(int id)
        {
            var person = _read.GetByIdAsync(id).Result;

            _write.Remove(person);
            _write.SaveAsync().Wait();
        }

        public PersonGetWithRelationsDto GetByIdWithRelations(int id)
        {
            var person = _read.GetPersonWithRelations(id);
            return _mapper.Map<PersonGetWithRelationsDto>(person);   
        }
    }
}

