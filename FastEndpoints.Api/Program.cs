using Common;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.RegisterCommonServices();
builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
