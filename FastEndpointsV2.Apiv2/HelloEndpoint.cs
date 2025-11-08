using Common;

namespace FastEndpoints.Api;

public class HelloEndpoint : EndpointWithoutRequest<string>
{
    public required IHelloWorldService HelloWorldService { get; set; }

    public override void Configure()
    {
        Get("/hello");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(HelloWorldService.GetHelloWorld(), ct);
    }
}