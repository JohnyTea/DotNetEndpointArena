using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class GetList : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IEnumerable<Todo>>
{
    private readonly ITodosService _svc;

    public GetList(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpGet("/todos")]
    public override async Task<ActionResult<IEnumerable<Todo>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var list = await _svc.GetList();
        return Ok(list);
    }
}