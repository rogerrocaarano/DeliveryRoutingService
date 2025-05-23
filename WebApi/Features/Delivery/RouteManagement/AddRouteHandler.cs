﻿using MediatR;
using WebApi.Persistence;

namespace WebApi.Features.Delivery.RouteManagement;

public class AddRouteHandler(ServiceDbContext db) : IRequestHandler<AddRouteCommand, Guid>
{
    public async Task<Guid> Handle(AddRouteCommand request, CancellationToken cancellationToken)
    {
        var route = new Domain.DeliveryRoute
        {
            Id = Guid.NewGuid(),
            StartingPoint = request.StartingPoint,
            AssignedVehicleId = request.AssignedVehicleId
        };
        try
        {
            await db.DeliveryRoutes.AddAsync(route, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
            return route.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}