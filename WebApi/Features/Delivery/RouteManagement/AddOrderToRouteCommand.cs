using MediatR;

namespace WebApi.Features.Delivery.RouteManagement;

public record AddOrderToRouteCommand(
    Guid RouteId,
    Guid OrderId
) : IRequest;