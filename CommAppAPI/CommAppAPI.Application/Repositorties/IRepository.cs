using CommAppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity // Base Entity yaptık çünkü Base Entityden türemeyen bir sınıf içeri sızamasın. Zaten Base Entity bir üst sınıf olduğu için alt sınıflar kolayca girebilir.
    {
    }
}
