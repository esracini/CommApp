using CommAppAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Contact
{
    public class ContactCreateDto
    {
        public int PersonId { get; set; }   // Hangi kişiye ait
        public ContactType Type { get; set; } // Enum: Email, Phone vs.
        public string Value { get; set; }   // Telefon numarası, mail adresi vs.
    }
}
