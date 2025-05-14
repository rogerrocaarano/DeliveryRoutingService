using MediatR;
using WebApi.Persistence;
using WebApi.Domain;

namespace WebApi.Features.DeliveryRoutes.GetDeliveryRoute;

public class GetDeliveryRouteHandler(ServiceDbContext db) : IRequestHandler<GetDeliveryRouteCommand, DeliveryRoute>
{
    public async Task<DeliveryRoute> Handle(GetDeliveryRouteCommand request, CancellationToken cancellationToken)
    {
        var route = await db.DeliveryRoutes.FindAsync([request.RouteId], cancellationToken);
        if (route == null)
        {
            throw new Exception($"Route with ID {request.RouteId} not found.");
        }

        return route;
    }
}
