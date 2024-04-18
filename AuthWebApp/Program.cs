using Novell.Directory.Ldap;
using ToDoItemLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();    
builder.Services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                }
                );


var app = builder.Build();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
