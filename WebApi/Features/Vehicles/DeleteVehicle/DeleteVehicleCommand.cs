using MediatR;

namespace WebApi.Features.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(Guid VehicleId) : IRequest;
