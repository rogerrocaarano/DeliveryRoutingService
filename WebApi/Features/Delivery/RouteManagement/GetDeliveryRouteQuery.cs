using MediatR;
using WebApi.Domain;

namespace WebApi.Features.Delivery.RouteManagement;

public record GetDeliveryRouteQuery(Guid RouteId) : IRequest<DeliveryRoute>;
