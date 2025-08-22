using ApplicationService;
using Infrastructure;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerInDevelopment();

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterHandlers();

var app = builder.Build();

app.UseSwaggerInDevelopment();

app.MapControllers();

app.Run();