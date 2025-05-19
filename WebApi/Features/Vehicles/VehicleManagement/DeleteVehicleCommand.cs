using MediatR;

namespace WebApi.Features.Vehicles.VehicleManagement;

public record DeleteVehicleCommand(Guid VehicleId) : IRequest;
