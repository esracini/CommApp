using CommAppAPI.Application.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Interfaces
{
    public interface IPersonService
    {
        List<PersonGetDto> GetAll();
        List<PersonGetWithRelationsDto> GetAllWithRelations();
        PersonGetWithRelationsDto GetByIdWithRelations(int id);
        PersonGetDto GetById(int id);
        PersonGetDto Add(PersonCreateDto dto);
        PersonGetDto Update(int id, PersonUpdateDto dto);
        void Delete(int id);
    }
}
