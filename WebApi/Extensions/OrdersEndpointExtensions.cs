using MediatR;
using WebApi.Features.DeliveryOrders.CreateDeliveryOrder;
using WebApi.Features.DeliveryOrders.GetDeliveryOrder;

namespace WebApi.Extensions;

public static class OrdersEndpointExtensions
{
    public static void MapOrdersEndpoints(this WebApplication app)
    {
        app.MapPost("/orders/create", async (CreateOrderCommand command, ISender sender) =>
        {
            var orderId = await sender.Send(command);
            return Results.Created($"/orders/{orderId}", orderId);
        });

        app.MapGet("/orders/{orderId}", async (Guid orderId, ISender sender) =>
        {
            var order = await sender.Send(new GetDeliveryOrderCommand(orderId));
            return Results.Ok(order);
        });
    }
}