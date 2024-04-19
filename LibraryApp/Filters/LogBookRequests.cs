using Library.Data;
using Library.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApp.Filters
{
    public class LogBookRequests : ActionFilterAttribute
    {
        private IRepository<Log> logger;
        private IHttpContextAccessor httpContextAccessor;

        public LogBookRequests(IRepository<Log> logger
            , IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity.Name;
            logger.Add(new Log { CreatedDate = DateTime.Now
                                , Message = $"User Accessed {httpContextAccessor.HttpContext.Request.Path}"
                                , User = user});

            base.OnActionExecuting(context);
        }
    }
}
