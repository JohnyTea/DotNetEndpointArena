using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class GetHello : EndpointBaseSync
    .WithoutRequest
    .WithActionResult<string>
{
    private readonly IHelloWorldService _helloWorldService;

    public GetHello(IHelloWorldService helloWorldService)
    {
        _helloWorldService = helloWorldService;
    }

    [HttpGet("/hello")]
    public override ActionResult<string> Handle()
    {
        var message = _helloWorldService.GetHelloWorld();
        return Ok(message);
    }
}