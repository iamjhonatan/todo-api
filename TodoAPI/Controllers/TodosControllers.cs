using Dapper.Contrib.Extensions;
using TodoAPI.Data;

namespace TodoAPI.Controllers;

public static class TodosControllers
{
    public static void MapTodosControllers(this WebApplication app)
    {
        app.MapGet("/", () => $"Welcome to the TodosAPI- {DateTime.Now}");

        app.MapGet("/todos", async (TodoContext.GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var todos = con.GetAll<Todo>().ToList();

            return Results.Ok(todos);
        });
        
        
    }
}