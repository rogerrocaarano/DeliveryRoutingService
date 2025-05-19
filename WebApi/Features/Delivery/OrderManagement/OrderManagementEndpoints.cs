using MediatR;

namespace WebApi.Features.Delivery.OrderManagement;

public static class OrderManagementEndpoints
{
    private const string EndpointName = "delivery/orders";
    public static void MapOrderManagementEndpoints(this WebApplication app)
    {
        app.MapPost($"/{EndpointName}/add", async (AddOrderCommand command, ISender sender) =>
        {
            var orderId = await sender.Send(command);
            return Results.Created($"/{EndpointName}/{orderId}", orderId);
        });

        app.MapGet($"{EndpointName}/{{orderId}}", async (Guid orderId, ISender sender) =>
        {
            var order = await sender.Send(new GetDeliveryOrderQuery(orderId));
            return Results.Ok(order);
        });
    }
}