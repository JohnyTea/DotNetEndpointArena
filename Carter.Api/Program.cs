using Carter;
using Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.RegisterCommonServices();

var app = builder.Build();

app.MapCarter();

app.Run();
