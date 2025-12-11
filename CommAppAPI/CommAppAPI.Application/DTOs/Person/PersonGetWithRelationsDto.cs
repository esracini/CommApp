using CommAppAPI.Application.DTOs.Company;
using CommAppAPI.Application.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Person
{
    public class PersonGetWithRelationsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CompanyGetDto Company { get; set; }
        public List<ContactGetDto> Contacts { get; set; }
    }
}
