using Library.Data;
using Library.DataContext;
using Library.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();

builder.Services.AddDbContext<LibraryContext>(
            options => options.UseNpgsql(builder.Configuration
        .GetConnectionString("DefaultConStr"))
    );

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<User>,UserRepository>();


var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
