namespace MiddleWareDemo.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            File.AppendAllText("Log.txt",$"Request Path { context.Request.Path }, Date : {DateTime.Now}");

            await _next(context);
        }
    }
}
