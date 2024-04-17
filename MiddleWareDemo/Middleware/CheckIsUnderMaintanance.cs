using Microsoft.Extensions.Configuration;

namespace MiddleWareDemo.Middleware
{
    public class CheckIsUnderMaintanance
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        ILogger<CheckIsUnderMaintanance> _logger;

        public CheckIsUnderMaintanance(RequestDelegate requestDelegate
                                       ,IConfiguration configuration
                                        ,ILogger<CheckIsUnderMaintanance> logger)
        {
            _next = requestDelegate;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {

            //File.WriteAllText("Log.txt", $"Request for path -> {context.Request.Path} " +
            //  $"  Date: {DateTime.Now}");
            var isUnderMain = _configuration.GetValue<bool>("IsUnderMain");
            if (isUnderMain)
            {
                _logger.LogWarning("Application is under mainrainance");
                await context.Response.WriteAsync("The applciation is under maintanance");
            }
            else
                await _next(context);
            }

       
    }

    public static class CheckUnderMaintananceExtention
    {
        public static IApplicationBuilder UseCheckMaintanance(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<CheckIsUnderMaintanance>();
        }
    }
}
