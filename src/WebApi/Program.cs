using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Foo";

builder.Services.RegisterDbContext(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
