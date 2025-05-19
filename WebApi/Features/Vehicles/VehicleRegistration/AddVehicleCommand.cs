using MediatR;

namespace WebApi.Features.Vehicles.VehicleRegistration;

public record AddVehicleCommand(
    Guid VehicleId,
    float Capacity
) : IRequest<Guid>;
