using Common;

namespace FastEndpoints.Api;

public class GetLargeTodosEndpoint : EndpointWithoutRequest<object>
{
    private readonly ITodosService _svc;

    public GetLargeTodosEndpoint(ITodosService svc)
    {
        _svc = svc;
    }

    public override void Configure()
    {
        Get("/todos/large");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var big = await _svc.GetBigList();
        await Send.OkAsync(big, ct);
    }
}