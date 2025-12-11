using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities;
using CommAppAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Persistence.Repositories
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(CommAppAPIDbContext context) : base(context)
        {
        }
    }
}
