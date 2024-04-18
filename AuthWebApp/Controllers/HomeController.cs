using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoItemLibrary;

namespace AuthWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        IToDoItemService _itemService;

        public HomeController(IToDoItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var claims = HttpContext.User;
            var userName = claims.FindFirst(ClaimTypes.Name);

            ///todoService.GetTodoItemForCurrentUser(1234);
            ViewBag.UserName = userName.Value;
            ViewBag.ToDoItems = string.Join(",", _itemService.GetToDoItemsForCurrentUser());
            return View();
        }
    }
}
