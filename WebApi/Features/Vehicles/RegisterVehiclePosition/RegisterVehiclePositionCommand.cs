using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Vehicles.RegisterVehiclePosition;

public record RegisterVehiclePositionCommand(
    Guid VehicleId,
    Coordinates Position,
    DateTime Timestamp
) : IRequest<Guid>;
