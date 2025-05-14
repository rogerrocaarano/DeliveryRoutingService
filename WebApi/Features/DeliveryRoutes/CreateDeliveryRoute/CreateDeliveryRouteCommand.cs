using MediatR;
using WebApi.Domain;

namespace WebApi.Features.DeliveryRoutes.CreateDeliveryRoute;

public record CreateDeliveryRouteCommand(
    Guid AssignedVehicleId,
    Coordinates StartingPoint
) : IRequest<Guid>;