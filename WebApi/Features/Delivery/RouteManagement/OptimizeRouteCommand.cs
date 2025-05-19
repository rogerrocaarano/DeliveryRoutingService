using MediatR;

namespace WebApi.Features.Delivery.RouteManagement;

public record OptimizeRouteCommand(Guid RouteId) : IRequest;