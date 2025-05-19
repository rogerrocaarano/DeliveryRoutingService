using MediatR;

namespace WebApi.Features.Vehicles.VehicleRegistration;

public record DeleteVehicleCommand(Guid VehicleId) : IRequest;
