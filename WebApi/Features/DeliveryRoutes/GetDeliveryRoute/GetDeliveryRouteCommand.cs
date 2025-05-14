using MediatR;
using WebApi.Domain;

namespace WebApi.Features.DeliveryRoutes.GetDeliveryRoute;

public record GetDeliveryRouteCommand(Guid RouteId) : IRequest<DeliveryRoute>;
