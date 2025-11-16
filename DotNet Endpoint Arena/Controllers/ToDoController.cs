using Common;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Endpoint_Arena.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController(ITodosService todosService) : ControllerBase
{

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Todo>> GetById(int id)
    {
        try
        {
            var todo = await todosService.GetById(id);
            return Ok(todo);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] TodoCreateReq req)
    {
        todosService.Create(req);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<Todo>>> GetList()
    {
        var list = await todosService.GetList();
        return Ok(list);
    }

    [HttpGet("large")]
    public async Task<ActionResult<IReadOnlyCollection<Todo>>> GetLargeList()
    {
        var big = await todosService.GetBigList();
        return Ok(big);
    }

    [HttpGet("compute")]
    public async Task<ActionResult<long>> Get()
    {
        var sum = await todosService.Compute();
        return Ok(new { sum });
    }
}
