using Carter;
using Common;

namespace Carter.Api;

public class TodoModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/todos/{id:int}", async (int id, ITodosService todoService) =>
        {
            try
            {
                var todo = await todoService.GetById(id);
                return Results.Ok(todo);
            }
            catch (KeyNotFoundException)
            {
                return Results.NotFound();
            }
        });

        app.MapPost("/todos", (TodoCreateReq req, ITodosService todoService) =>
        {
            todoService.Create(req);
            return Results.NoContent();
        });

        app.MapGet("/todos", async (ITodosService todoService) =>
        {
            var list = await todoService.GetList();
            return Results.Ok(list);
        });

        app.MapGet("/todos/large", async (ITodosService todoService) =>
        {
            var big = await todoService.GetBigList();
            return Results.Ok(big);
        });

        app.MapGet("/todos/compute", async (ITodosService todoService) =>
        {
            var sum = await todoService.Compute();
            return Results.Ok(new { sum });
        });
    }
}