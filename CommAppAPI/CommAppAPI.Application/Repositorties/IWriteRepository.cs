using CommAppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model); //işlem başarılıysa true dönsün istediğimiz için dönüş değeri bool oldu.
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task <bool> RemoveAsync(int id); 
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
