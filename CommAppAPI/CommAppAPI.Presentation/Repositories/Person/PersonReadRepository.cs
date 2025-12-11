using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities;
using CommAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Persistence.Repositories
{
    public class PersonReadRepository : ReadRepository<Person>, IPersonReadRepository
    {
        private readonly CommAppAPIDbContext _context;
        public PersonReadRepository(CommAppAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Person> GetAllPersonsWithRelations() //Eager Loading ve AsNoTracking optimizasyonu.
        {
            return _context.Persons
                .Include(p => p.Company)
                .Include(p => p.Contacts)
                .AsNoTracking();
            
        }

        public Person GetPersonWithRelations(int id)
        {
            return _context.Persons
                .Include(p => p.Company)
                .Include(p => p.Contacts)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
