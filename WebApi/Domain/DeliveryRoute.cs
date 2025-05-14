using WebApi.Domain.Enums;

namespace WebApi.Domain;

public class DeliveryRoute
{
    public Guid Id { get; set; }
    public Guid AssignedVehicleId { get; set; }
    public required Coordinates StartingPoint { get; set; }
    public List<Guid> OrderIds { get; set; } = [];
    public RouteStatus Status { get; set; } = RouteStatus.Created;
}