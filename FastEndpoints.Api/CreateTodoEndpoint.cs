using Common;

namespace FastEndpoints.Api;

public class CreateTodoEndpoint : Endpoint<TodoCreateReq>
{
    private readonly ITodosService _svc;

    public CreateTodoEndpoint(ITodosService svc)
    {
        _svc = svc;
    }

    public override void Configure()
    {
        Post("/todos");
        AllowAnonymous();
    }

    public override Task HandleAsync(TodoCreateReq req, CancellationToken ct)
    {
        _svc.Create(req);
        return Send.NoContentAsync(ct);
    }
}