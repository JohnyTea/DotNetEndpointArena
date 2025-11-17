using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class GetLargeList : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IEnumerable<Todo>>
{
    private readonly ITodosService _svc;

    public GetLargeList(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpGet("/todos/large")]
    public override async Task<ActionResult<IEnumerable<Todo>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var big = await _svc.GetBigList();
        return Ok(big);
    }
}