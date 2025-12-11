using CommAppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}
