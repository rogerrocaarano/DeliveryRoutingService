using MediatR;
using WebApi.Features.Delivery.OrderManagement;

namespace WebApi.Extensions;

public static class OrdersEndpointExtensions
{
    public static void MapOrdersEndpoints(this WebApplication app)
    {
        app.MapPost("/orders/create", async (AddOrderCommand command, ISender sender) =>
        {
            var orderId = await sender.Send(command);
            return Results.Created($"/orders/{orderId}", orderId);
        });

        app.MapGet("/orders/{orderId}", async (Guid orderId, ISender sender) =>
        {
            var order = await sender.Send(new GetDeliveryOrderQuery(orderId));
            return Results.Ok(order);
        });
    }
}