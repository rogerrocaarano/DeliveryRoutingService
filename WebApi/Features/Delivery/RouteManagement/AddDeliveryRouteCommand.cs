using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.RouteManagement;

public record AddDeliveryRouteCommand(
    Guid AssignedVehicleId,
    Coordinates StartingPoint
) : IRequest<Guid>;