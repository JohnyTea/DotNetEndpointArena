using Common;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();
builder.Services.RegisterCommonServices();

var app = builder.Build();

// Map controllers to endpoints
app.MapControllers();

app.Run();
