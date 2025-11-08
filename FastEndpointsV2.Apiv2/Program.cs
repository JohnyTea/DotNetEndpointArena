using Common;
using FastEndpoints;
using FastEndpoints.Api;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(o =>
{
    o.Assemblies = [typeof(HelloEndpoint).Assembly];
});

builder.Services.RegisterCommonServices();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();