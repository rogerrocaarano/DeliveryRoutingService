using MediatR;

namespace WebApi.Features.Delivery.RouteManagement;

public static class RouteManagementEndpoints
{
    private const string EndpointName = "delivery/routes";

    public static void MapRouteManagementEndpoints(this WebApplication app)
    {
        app.MapPost($"/{EndpointName}/add",
            async (AddRouteCommand command, ISender sender) =>
            {
                var routeId = await sender.Send(command);
                return Results.Created($"/{EndpointName}/{routeId}", routeId);
            });

        app.MapGet($"/{EndpointName}/{{routeId:guid}}",
            async (Guid routeId, ISender sender) =>
            {
                var route = await sender.Send(new GetRouteQuery(routeId));
                return Results.Ok(route);
            });

        app.MapPost($"/{EndpointName}/{{routeId:guid}}/add-order/{{orderId:guid}}",
            async (Guid routeId, Guid orderId, ISender sender) =>
            {
                await sender.Send(new AddOrderToRouteCommand(routeId, orderId));
                return Results.Ok();
            });

        app.MapPost($"/{EndpointName}/{{routeId:guid}}/optimize",
            async (Guid routeId, ISender sender) =>
            {
                await sender.Send(new OptimizeRouteCommand(routeId));
                return Results.Ok();
            });
    }
}