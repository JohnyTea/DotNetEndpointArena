using Common;

namespace FastEndpoints.Api;

public class HelloEndpoint : Endpoint<EmptyRequest, string>
{
    public IHelloWorldService _helloService { get; set; }

    public override void Configure()
    {
        Get("/Hello");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken tc)
    {
        await Send.OkAsync(_helloService.GetHelloWorld());
    }
}