using MediatR;
using WebApi.Features.DeliveryRoutes.AddDeliveryOrderToDeliveryRoute;
using WebApi.Features.DeliveryRoutes.CreateDeliveryRoute;
using WebApi.Features.DeliveryRoutes.GetDeliveryRoute;

namespace WebApi.Extensions;

public static class RoutesEndpointExtensions
{
    public static void MapRoutesEndpoints(this WebApplication app)
    {
        app.MapPost("/routes/create", async (CreateDeliveryRouteCommand command, ISender sender) =>
        {
            var routeId = await sender.Send(command);
            return Results.Created($"/routes/{routeId}", routeId);
        });
        
        app.MapPost("/routes/{routeId}/add-order", async (Guid routeId, AddDeliveryOrderToDeliveryRouteCommand command, ISender sender) =>
        {
            command = command with { RouteId = routeId };
            await sender.Send(command);
            return Results.NoContent();
        });

        app.MapGet("/routes/{routeId}", async (Guid routeId, ISender sender) =>
        {
            var route = await sender.Send(new GetDeliveryRouteCommand(routeId));
            return Results.Ok(route);
        });
    }
}
