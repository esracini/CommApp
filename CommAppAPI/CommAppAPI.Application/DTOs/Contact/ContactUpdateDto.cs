using CommAppAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.DTOs.Contact
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }  // Güncellenebilir
        public string Value { get; set; }      // Yeni iletişim bilgisi
        public int PersonId { get; set; }      // İstersek taşıyabilsin
    }
}
