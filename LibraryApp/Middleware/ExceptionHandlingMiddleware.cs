namespace LibraryApp.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                File.AppendAllText("ErrorLog.txt", ex.Message);
            }
        }
    }
}
