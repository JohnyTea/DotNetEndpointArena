using Carter;
using Common;

namespace Carter.Api;

public class HelloModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/hello", (IHelloWorldService hello) => hello.GetHelloWorld());

        app.MapGet("/", () => "Hello from Carter!");
    }
}