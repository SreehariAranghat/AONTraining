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
    public class BookRepository : Repository<Book>
    {
        IMemoryCache _cache;
        ILogger<BookRepository> _logger;
        public BookRepository(LibraryContext context
            ,IMemoryCache cache
            ,ILogger<BookRepository> logger
            ) : base(context) { 
             
            this._cache = cache;
            _logger = logger;
        }

        public override List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
