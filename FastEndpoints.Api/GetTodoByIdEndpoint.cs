using Common;

namespace FastEndpoints.Api;

public class GetTodoByIdRequest
{
    public int Id { get; set; } 
}

public class GetTodoByIdEndpoint : Endpoint<GetTodoByIdRequest, object>
{
    private readonly ITodosService _svc;

    public GetTodoByIdEndpoint(ITodosService svc)
    {
        _svc = svc;
    }

    public override void Configure()
    {
        Get("/todos/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetTodoByIdRequest req, CancellationToken ct)
    {
        try
        {
            var todo = await _svc.GetById(req.Id);
            await Send.OkAsync(todo, ct);
        }
        catch (KeyNotFoundException)
        {
            await Send.NotFoundAsync(ct);
        }
    }
}
