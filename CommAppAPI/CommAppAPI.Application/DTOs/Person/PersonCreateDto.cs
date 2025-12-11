using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Person
{
    public class PersonCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
    }
}
