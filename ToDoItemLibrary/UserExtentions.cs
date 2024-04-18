using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItemLibrary
{
    public static class UserExtentions
    {
        public static int GetUserId(this IHttpContextAccessor httpContext)
        {
            int userId = int.Parse(httpContext.HttpContext
                .User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }
    }
}
