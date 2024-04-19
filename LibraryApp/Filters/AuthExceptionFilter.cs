using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApp.Filters
{
    public class AuthExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is UserNotFoundException)
            {
                File.AppendAllText("AuditLog.txt", $"Failed login attempt by user : {context.Exception.Message}");
            

                context.Result = new ContentResult
                {
                    Content = "Invalid Username or Password",
                    ContentType = "text/json",
                    StatusCode = 401
                };
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "Houston we have a problem",
                    StatusCode = 500
                };
            }
        }
    }
}
