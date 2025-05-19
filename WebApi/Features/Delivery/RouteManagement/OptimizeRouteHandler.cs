using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Extensions.GraphHopper;
using WebApi.Persistence;

namespace WebApi.Features.Delivery.RouteManagement;

public class OptimizeRouteHandler(ServiceDbContext db, GraphHopperAdapter optimizer)
    : IRequestHandler<OptimizeRouteCommand>
{
    public async Task Handle(OptimizeRouteCommand request, CancellationToken cancellationToken)
    {
        var route = await db.DeliveryRoutes.FindAsync([request.RouteId], cancellationToken);
        if (route == null)
        {
        }

        if (route.AssignedVehicleId == Guid.Empty)
        {
        }

        var vehicle = await db.Vehicles.FindAsync([route.AssignedVehicleId], cancellationToken);
        var orders = await db.Orders
            .Where(o => o.AssignedRouteId == route.Id)
            .ToListAsync(cancellationToken);

        try
        {
            var sortedOrders = await optimizer.GetOptimizedRoute(route, vehicle, orders);
            for (var i = 0; i < sortedOrders.Count; i++)
            {
                var order = orders.First(o => o.Id == sortedOrders[i]);
                await UpdateOrderPosition(order, i);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task UpdateOrderPosition(DeliveryOrder order, int i)
    {
        order.PositionInRoute = i;
        try
        {
            db.Update(order);
            await db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}