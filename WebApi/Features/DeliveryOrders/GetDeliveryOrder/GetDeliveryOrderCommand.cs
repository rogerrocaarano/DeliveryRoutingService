using MediatR;
using WebApi.Domain;

namespace WebApi.Features.DeliveryOrders.GetDeliveryOrder;

public record GetDeliveryOrderCommand(Guid OrderId) : IRequest<DeliveryOrder>;