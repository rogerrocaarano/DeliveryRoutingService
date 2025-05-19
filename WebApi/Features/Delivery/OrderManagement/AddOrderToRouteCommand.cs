using MediatR;

namespace WebApi.Features.Delivery.OrderManagement;

public record AddOrderToRouteCommand(
    Guid RouteId,
    Guid OrderId
) : IRequest;