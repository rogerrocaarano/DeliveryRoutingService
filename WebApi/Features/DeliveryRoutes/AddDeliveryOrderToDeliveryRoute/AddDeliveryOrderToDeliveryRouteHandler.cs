using MediatR;
using WebApi.Persistence;

namespace WebApi.Features.DeliveryRoutes.AddDeliveryOrderToDeliveryRoute;

public class AddDeliveryOrderToDeliveryRouteHandler(ServiceDbContext db)
    : IRequestHandler<AddDeliveryOrderToDeliveryRouteCommand>
{
    public async Task Handle(AddDeliveryOrderToDeliveryRouteCommand request, CancellationToken cancellationToken)
    {
        var route = await db.DeliveryRoutes.FindAsync([request.RouteId], cancellationToken);
        if (route == null)
        {
            throw new Exception($"Route with ID {request.RouteId} not found.");
        }

        var order = await db.Orders.FindAsync([request.OrderId], cancellationToken);
        if (order == null)
        {
            throw new Exception($"Order with ID {request.OrderId} not found.");
        }

        try
        {
            route.OrderIds.Add(order.Id);
            db.DeliveryRoutes.Update(route);
            await db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}