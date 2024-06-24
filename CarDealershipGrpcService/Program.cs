using CarDealershipGrpcService.Services;
using CarDealershipRestApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<CarDealershipContext>(options =>
    options.UseInMemoryDatabase("CarDealershipDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CarDealershipService>();
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client.");
});

app.Run();
