using FastEndpoints;

namespace FastEndpoints.Api;
public class MyEndpoint : Endpoint<EmptyRequest, EmptyResponse>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        await Send.OkAsync();
    }
}