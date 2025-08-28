using ApplicationService;
using Infrastructure;
using WebApi.Extensions;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerInDevelopment();

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterHandlers();

var app = builder.Build();

app.UseCustomExceptionHandler();

app.UseSwaggerInDevelopment();

app.MapControllers();

app.Run();