using MiddleWareDemo.Middleware;
using Serilog.Extensions;
using Serilog;
using MiddleWareDemo.Service;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging(options =>
{
    options.AddDebug();
    options.AddConsole();
    options.AddSerilog() ;
}
); ;

builder.Configuration.AddJsonFile("themeSettings.json");


builder.Services.Configure<ThemeSettings>(
    builder.Configuration.GetSection("Theme")
);
builder.Services.AddScoped<IThemeService, ThemeService>();

builder.Services.AddControllers();
builder.Services.AddMvc();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseCheckMaintanance();
//app.UseAuthentication();
app.UseRouting();
//app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
