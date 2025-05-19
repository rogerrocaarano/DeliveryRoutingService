using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.RouteManagement;

public record AddRouteCommand(
    Guid AssignedVehicleId,
    Coordinates StartingPoint
) : IRequest<Guid>;