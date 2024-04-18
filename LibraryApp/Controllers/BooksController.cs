using Library.Data;
using Library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        IRepository<Book> _booksRepository;

        public BooksController(IRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
