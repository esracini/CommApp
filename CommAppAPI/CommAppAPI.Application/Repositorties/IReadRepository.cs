using CommAppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T>  where T : BaseEntity  //Bir interface başka bir interfaceden miras alabilir.
    {
        IQueryable<T> GetAll();  //Iqueryable verilerin db tarafında sorgulanmasını sağlar, IEnumarable olsaydı bütün verileri Ram'e taşırdık.
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method); //Expression sayesinde koşul db tarafında çalışır Iqueryable olarak döner.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); //koşulu sağlayan ilk kaydı getirir.
        Task<T> GetByIdAsync(int id);
    }
}
