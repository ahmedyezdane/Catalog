using ApplicationService;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Foo";

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterHandlers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
