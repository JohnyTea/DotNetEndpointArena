using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class HelloEndpoint : EndpointBaseSync
 .WithoutRequest
 .WithActionResult<string>
{
    public HelloEndpoint(IHelloWorldService helloWorldService)
    {
        HelloWorldService = helloWorldService;
    }

    public IHelloWorldService HelloWorldService { get; }

    [HttpGet("hello")]
    public override ActionResult<string> Handle()
    {
        // Your logic here

        return HelloWorldService.GetHelloWorld();
    }
}