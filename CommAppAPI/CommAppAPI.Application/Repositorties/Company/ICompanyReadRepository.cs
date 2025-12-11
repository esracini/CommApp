using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Repositories
{
    public interface ICompanyReadRepository:IReadRepository<Company>
    {
        public Company GetCompanyDetails(int id);
    }
}
