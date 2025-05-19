using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.OrderManagement;

public record GetDeliveryOrderQuery(Guid OrderId) : IRequest<DeliveryOrder>;