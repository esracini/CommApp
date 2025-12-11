using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities.Common;
using CommAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly CommAppAPIDbContext _context;

        public WriteRepository(CommAppAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //T hangi entity ise onun DbSet'ini otomatik çekmek.

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);  //Change Tracker yönetiyor.
            return entityEntry.State==EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
           await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State==EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == id);
            return Remove(model);
        }

        public bool Update(T model)
        {
           EntityEntry<T> entityEntry=Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            =>await _context.SaveChangesAsync();  //expression-bodied method automatically return vardır.

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
    }
}
