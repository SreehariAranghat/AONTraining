using Library.DataContext;
using Library.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        IMemoryCache _cache;
        ILogger<UserRepository> _logger;

        public UserRepository(LibraryContext context,IMemoryCache cache
            ,ILogger<UserRepository> logger
            ) 
            : base(context) {
            _cache = cache;
            _logger = logger;
        }

        public override User Add(User entity)
        {
            if(DbContext.Set<User>().Any(d => d.Email == entity.Email))
            {
                throw new Exception("User with the same email address already exist");
            }

            return base.Add(entity);
        }

        public override List<User> GetAll()
        {
            if (_cache.TryGetValue("users", out List<User> books))
            {
                _logger.LogInformation("Users was accessed from cache ");
                return books;
            }
            else
            {
                _logger.LogInformation("Users was not found on cache fetching from db");
                var b = base.GetAll();
                _cache.Set("users", b);

                return b;
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }

        public User FromEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException();


            var user = DbContext.Set<User>().FirstOrDefault(
                d => d.Email == email);

            if (user == null)
            {
                throw new UserNotFoundException($"User with the email {email} is not found");
            }

            return user;
        }
    }
}
