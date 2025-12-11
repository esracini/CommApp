using CommAppAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Contact
{
    public class ContactGetDto
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public int PersonId { get; set; }
    }
}
