using MediatR;

namespace WebApi.Features.Delivery.RouteManagement;

public record OptimizeDeliveryRouteCommand(Guid RouteId) : IRequest;