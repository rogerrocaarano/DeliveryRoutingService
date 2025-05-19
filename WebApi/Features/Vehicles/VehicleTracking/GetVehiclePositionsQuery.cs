using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Vehicles.VehicleTracking;

public record GetVehiclePositionsQuery(Guid VehicleId) : IRequest<List<VehiclePosition>>;
