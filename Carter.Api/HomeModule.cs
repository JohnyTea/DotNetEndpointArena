using Carter;
using Common;

namespace Carter.Api;

public class HomeModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Home", (IHelloWorldService hello) => hello.GetHelloWorld());
    }
}