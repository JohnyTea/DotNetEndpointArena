using Ardalis.ApiEndpoints;
using Common;
using Microsoft.AspNetCore.Mvc;

public class GetById : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<Todo>
{
    private readonly ITodosService _svc;

    public GetById(ITodosService svc)
    {
        _svc = svc;
    }

    [HttpGet("/todos/{id:int}")]
    public override async Task<ActionResult<Todo>> HandleAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var todo = await _svc.GetById(id);
            return Ok(todo);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}