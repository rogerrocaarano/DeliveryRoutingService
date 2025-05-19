using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.OrderManagement;

public record AddOrderCommand(
    Guid OrderId,
    Coordinates DeliveryPoint,
    float Volume
) : IRequest<Guid>;