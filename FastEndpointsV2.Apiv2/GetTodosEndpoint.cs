using Common;

namespace FastEndpoints.Api;

public class GetTodosEndpoint : EndpointWithoutRequest<object>
{
    private readonly ITodosService _svc;

    public GetTodosEndpoint(ITodosService svc)
    {
        _svc = svc;
    }

    public override void Configure()
    {
        Get("/todos");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var list = await _svc.GetList();
        await Send.OkAsync(list, ct);
    }
}