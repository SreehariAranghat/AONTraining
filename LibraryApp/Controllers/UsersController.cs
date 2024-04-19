using Library.Data;
using Library.DataContext;
using Library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var user = _userRepository.FindById(id);
            if(user == null)
            {
                ViewBag.Message = "User Does Not Exist";
               
            }
            else
            {
                ViewBag.Message = $"User {user.Name} Found";
            }

            return View();
        }
    }
}
