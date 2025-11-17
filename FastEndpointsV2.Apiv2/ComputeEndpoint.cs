using Common;

namespace FastEndpoints.Api;

public class ComputeEndpoint : EndpointWithoutRequest<object>
{
    private readonly ITodosService _svc;

    public ComputeEndpoint(ITodosService svc)
    {
        _svc = svc;
    }

    public override void Configure()
    {
        Get("/todos/compute");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var sum = await _svc.Compute();
        await Send.OkAsync(new { sum }, ct);
    }
}