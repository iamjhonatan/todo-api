using TodoAPI.Controllers;
using TodoAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

var app = builder.Build();

app.MapTodosControllers();

app.Run();