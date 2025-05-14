using MediatR;
using WebApi.Domain;

namespace WebApi.Features.DeliveryOrders.CreateDeliveryOrder;

public record CreateOrderCommand(
    Guid OrderId,
    Coordinates DeliveryPoint,
    float Volume
) : IRequest<Guid>;