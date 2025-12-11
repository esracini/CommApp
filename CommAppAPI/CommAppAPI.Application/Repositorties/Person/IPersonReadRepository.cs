using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Repositories
{
    public interface IPersonReadRepository:IReadRepository<Person>
    {
        IQueryable<Person> GetAllPersonsWithRelations();
        Person GetPersonWithRelations(int id);
    }
}
