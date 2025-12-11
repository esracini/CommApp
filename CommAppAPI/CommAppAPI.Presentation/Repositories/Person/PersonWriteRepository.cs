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
    public class PersonWriteRepository : WriteRepository<Person>,IPersonWriteRepository
    {
        public PersonWriteRepository(CommAppAPIDbContext context) : base(context)
        {
        }
    }
}
