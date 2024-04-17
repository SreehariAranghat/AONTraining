using Microsoft.AspNetCore.Http.HttpResults;
using MyAppLibarary.ForgotPassword;
using MyAppLibarary.SMS;
using MyAppLibarary;

var builder = WebApplication.CreateBuilder(args);

//Services to be added here
builder.Services.AddControllers();
builder.Services.AddMvc();
//builder.Services.AddMvc();`

builder.Services.RegisterPlatform();
builder.Services.RegisterAppServices();


var app = builder.Build();

//Configure the middlewares

app.UseStaticFiles();
app.UseRouting();
//app.MapDefaultControllerRoute();

app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
