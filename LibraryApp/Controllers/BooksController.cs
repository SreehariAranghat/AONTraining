using Library.Data;
using Library.Entities;
using LibraryApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        IRepository<Book> _booksRepository;

        public BooksController(IRepository<Book> booksRepository
                               )
        {
            _booksRepository = booksRepository;
        }

        [ProducesDefaultResponseType(typeof(List<Book>))]
        [HttpGet]
        [MesureRuntimeFilter()]
        public IActionResult Get()
        {
        
            var books = _booksRepository.GetAll();
            return Ok(books);
        }
    }
}
