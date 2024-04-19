using Library.Data;
using Library.DataContext;
using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddLogging(options => options.AddConsole());
builder.Services.AddControllers();
builder.Services.AddMemoryCache();

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

builder.Services.AddDbContext<LibraryContext>(
            options => options.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConStr"))
    );

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository,UserRepository>();


var app = builder.Build();

app.UseAuthentication();
app.UseRouting();
//app.MapControllers();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
