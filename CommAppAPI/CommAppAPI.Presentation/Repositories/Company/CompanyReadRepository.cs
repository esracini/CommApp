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
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        private readonly CommAppAPIDbContext _context;
        public CompanyReadRepository(CommAppAPIDbContext context) : base(context)
        {
            _context = context;
        }
        public Company GetCompanyDetails(int id)
        {
            return _context.Companies
                .Include(c => c.Persons)
                .ThenInclude(p => p.Contacts)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

    }
}
