using WebApi.Domain.Enums;

namespace WebApi.Domain;

public class DeliveryOrder
{
    public Guid Id { get; set; }
    public required Coordinates DeliveryPoint { get; set; }
    public OrderStatus Status  { get; set; }
    public DateTime UpdateTimeStamp { get; set; }
    public Guid AssignedRouteId { get; set; }
    public float Volume { get; set; }
    public int PositionInRoute { get; set; } = 0;
}