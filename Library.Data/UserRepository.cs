using Library.DataContext;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }

        public override User Add(User entity)
        {
            if(DbContext.Set<User>().Any(d => d.Email == entity.Email))
            {
                throw new Exception("User with the same email address already exist");
            }

            return base.Add(entity);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
