using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Vehicles.VehicleTracking;

public record AddVehiclePositionCommand(
    Guid VehicleId,
    Coordinates Position,
    DateTime Timestamp
) : IRequest<Guid>;
