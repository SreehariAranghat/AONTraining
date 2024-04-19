using Library.Data;
using Library.DataContext;
using Library.Entities;
using LibraryApp.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddLogging(options => options.AddConsole());
builder.Services.AddControllers(option =>
{
    option.Filters.Add<AuthExceptionFilter>();
});
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilePath));
} 
);

builder.Services.AddAuthentication()
    
    .AddJwtBearer(
        option => option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a friday afternnon when the april sun is at the highest, It may reach 11 degrees"))
        }
    );
builder.Services.AddCors(
        options => options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        })
    );

builder.Services.AddDbContext<LibraryContext>(
            options => options.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConStr"))
    );

//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();


var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
   
});


app.UseAuthentication();
app.UseRouting();
//app.MapControllers();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
