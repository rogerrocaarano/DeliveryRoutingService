using MediatR;

namespace WebApi.Features.DeliveryRoutes.OptimizeDeliveryRoute;

public record OptimizeDeliveryRouteCommand(Guid RouteId) : IRequest;