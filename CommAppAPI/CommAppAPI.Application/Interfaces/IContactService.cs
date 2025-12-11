using CommAppAPI.Application.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Interfaces
{
    public interface IContactService
    {
        List<ContactGetDto> GetAll();
        ContactGetDto GetById(int id);
        ContactGetDto Add(ContactCreateDto dto);
        ContactGetDto Update(int id, ContactUpdateDto dto);
        void Delete(int id);
    }
}
