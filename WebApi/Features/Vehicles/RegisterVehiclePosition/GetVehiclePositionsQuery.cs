using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Vehicles.RegisterVehiclePosition;

public record GetVehiclePositionsQuery(Guid VehicleId) : IRequest<List<VehiclePosition>>;
