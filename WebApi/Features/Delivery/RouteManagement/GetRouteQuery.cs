using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.RouteManagement;

public record GetRouteQuery(Guid RouteId) : IRequest<DeliveryRoute>;
