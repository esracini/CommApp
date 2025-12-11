using CommAppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Domain.Entities
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
