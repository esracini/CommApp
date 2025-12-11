using CommAppAPI.Application.DTOs.Contact;
using System;
using System.Collections.Generic;
using CommAppAPI.Application.DTOs.Person;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Company
{
    public class CompanyGetDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<PersonGetDto> Persons { get; set; }

    }
}
