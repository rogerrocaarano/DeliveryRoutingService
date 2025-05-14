using MediatR;

namespace WebApi.Features.DeliveryRoutes.AddDeliveryOrderToDeliveryRoute;

public record AddDeliveryOrderToDeliveryRouteCommand(
    Guid RouteId,
    Guid OrderId
) : IRequest;