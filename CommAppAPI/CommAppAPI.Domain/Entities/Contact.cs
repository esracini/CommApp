using CommAppAPI.Domain.Entities.Common;
using CommAppAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Domain.Entities
{
    public class Contact:BaseEntity
    {
        public ContactType Type { get; set; } //iletişim tipini enum olarak alıyoruz.
        public string Value { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
