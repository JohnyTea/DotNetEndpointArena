using Common;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Endpoint_Arena.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController(IHelloWorldService helloWorldService) : ControllerBase
{

    [HttpGet(Name = "Hello")]
    public string Get()
    {
        return helloWorldService.GetHelloWorld();
    }
}
