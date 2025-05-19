using WebApi.Extensions.GraphHopper;
using WebApi.Features.Delivery.OrderManagement;
using WebApi.Features.Delivery.RouteManagement;
using WebApi.Features.Vehicles.VehicleTracking;
using WebApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ServiceDbContext, InMemoryServiceDbContext>();

builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register GraphHopperClient and GraphHopperAdapter
builder.Services.AddSingleton<GraphHopperClient.GraphHopperClient>(sp =>
{
    // Replace with your actual API key or retrieve from configuration
    var apiKey = builder.Configuration["GraphHopper:ApiKey"] ?? "YOUR_API_KEY";
    return new GraphHopperClient.GraphHopperClient(apiKey);
});
builder.Services.AddSingleton<GraphHopperAdapter>();

builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapRouteManagementEndpoints();
app.MapOrderManagementEndpoints();
app.MapVehicleTrackingEndpoints();

app.Run();