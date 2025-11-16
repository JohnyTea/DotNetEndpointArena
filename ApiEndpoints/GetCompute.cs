using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class GetCompute : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<long>
{
    private readonly ITodosService _svc;

    public GetCompute(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpGet("/todos/compute")]
    public override async Task<ActionResult<long>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var sum = await _svc.Compute();
        return Ok(sum);
    }
}