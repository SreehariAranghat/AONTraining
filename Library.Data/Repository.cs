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

        public virtual T Add(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public virtual void Delete(int id)
        {
            var t = DbContext.Find<T>(id);
            DbContext.Remove<T>(t);
            DbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return DbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
           return DbContext.Set<T>().ToList();
        }

        public virtual T Update(T entity)
        {
            DbContext.Update<T>(entity);
            DbContext.SaveChanges();

            return entity;
        }
    }
}
