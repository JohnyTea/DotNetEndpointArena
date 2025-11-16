using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class Create : EndpointBaseSync
    .WithRequest<TodoCreateReq>
    .WithActionResult
{
    private readonly ITodosService _svc;

    public Create(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpPost("/todos")]
    public override ActionResult Handle([FromBody] TodoCreateReq request)
    {
        _svc.Create(request);
        return NoContent();
    }
}