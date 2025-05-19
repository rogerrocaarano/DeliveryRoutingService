using MediatR;

namespace WebApi.Features.Vehicles.CreateVehicle;

public record CreateVehicleCommand(
    Guid VehicleId,
    float Capacity
) : IRequest<Guid>;
