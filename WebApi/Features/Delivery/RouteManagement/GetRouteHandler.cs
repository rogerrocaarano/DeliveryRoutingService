using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Delivery.RouteManagement;

public class GetRouteHandler(ServiceDbContext db) : IRequestHandler<GetRouteQuery, DeliveryRoute>
{
    public async Task<DeliveryRoute> Handle(GetRouteQuery request, CancellationToken cancellationToken)
    {
        var route = await db.DeliveryRoutes.FindAsync([request.RouteId], cancellationToken);
        if (route == null)
        {
            throw new Exception($"Route with ID {request.RouteId} not found.");
        }

        return route;
    }
}
