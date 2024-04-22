using Library.DataContext;
using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Repository<T> : IRepository<T> where T : BaseObject
    {
        protected DbContext DbContext { get; private set; }

        public Repository(LibraryContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual async  Task<T> Add(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(int id)
        {
            var t = DbContext.Find<T>(id);
            DbContext.Remove<T>(t);
            await DbContext.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public  virtual async Task<List<T>> GetAll()
        {
           return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            DbContext.Update<T>(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }
    }
}
