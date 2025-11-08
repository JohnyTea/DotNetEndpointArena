using Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.RegisterCommonServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/hello", (IHelloWorldService helloWorldService) => Results.Ok(helloWorldService.GetHelloWorld()));

app.MapGet("/todos/{id:int}", (int id, ITodosService svc) =>
{
    try
    {
        var todo = svc.GetById(id);
        return Results.Ok(todo);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound();
    }
});

app.MapPost("/todos", (TodoCreateReq req, ITodosService svc) =>
{
    svc.Create(req);
    return Results.NoContent();
});

app.MapGet("/todos", (ITodosService svc) =>
{
    var list = svc.GetList();
    return Results.Ok(list);
});

app.MapGet("/todos/large", (ITodosService svc) =>
{
    var big = svc.GetBigList();
    return Results.Ok(big);
});

app.MapGet("/compute", (ITodosService svc) =>
{
    var sum = svc.Compute();
    return Results.Ok(new { sum });
});

app.Run();
