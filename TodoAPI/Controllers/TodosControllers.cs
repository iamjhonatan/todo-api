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

        app.MapGet("/todos/{id}", async (TodoContext.GetConnection connectionGetter, int id) =>
        {
            using var con = await connectionGetter();
            var todo = con.Get<Todo>(id);

            if (todo is null) return Results.NotFound();

            return Results.Ok(todo);
        });

        app.MapPost("/todos", async (TodoContext.GetConnection connectionGetter, Todo todo) =>
        {
            using var con = await connectionGetter();
            var id = con.Insert(todo);

            return Results.Created($"/todos/{id}", todo);
        });

        app.MapPut("/todos", async (TodoContext.GetConnection connectionGetter, Todo todo) =>
        {
            using var con = await connectionGetter();
            var id = await con.UpdateAsync(todo);

            return Results.Ok();
        });

        app.MapDelete("/todos/{id}", async (TodoContext.GetConnection connectionGetter, int id) =>
        {
            using var con = await connectionGetter();
            var todo = con.Get<Todo>(id);

            if (todo is null) return Results.NotFound();

            await con.DeleteAsync(todo);

            return Results.Ok(todo);
        });
    }
}