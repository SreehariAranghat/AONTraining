
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ToDoItemLibrary
{
    public class ToDoItem
    {
        public int UserId { get; set; }
        public string Title { get; set; }
    }

    public class ToDoItemService : IToDoItemService
    {
        List<ToDoItem> todoItems = new List<ToDoItem>();

        IHttpContextAccessor _context;

        public ToDoItemService(IHttpContextAccessor httpContext) {

            _context = httpContext;

            todoItems.Add(new ToDoItem { UserId = 1001, Title = "Complete Daily Task" });
            todoItems.Add(new ToDoItem { UserId = 1002, Title = "Complete Daily Task" });
            todoItems.Add(new ToDoItem { UserId = 1001, Title = "Complete Daily Task" });
        }

        public List<string> GetToDoItemsForCurrentUser()
        {
            if (_context.HttpContext.User.Identity.IsAuthenticated)
            {
                int loggedInUser = _context.GetUserId();

                return todoItems.Where(d => d.UserId == loggedInUser)
                                        .Select(d => d.Title).ToList();
            }
            else
                throw new Exception("User not logged in");
        }
    }
}
