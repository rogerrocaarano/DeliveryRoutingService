using MediatR;

namespace WebApi.Features.Vehicles.VehicleManagement;

public record AddVehicleCommand(
    Guid VehicleId,
    float Capacity
) : IRequest<Guid>;
