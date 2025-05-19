using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.VehicleTracking;

public class AddVehiclePositionHandler(ServiceDbContext db) : IRequestHandler<AddVehiclePositionCommand, Guid>
{
    public async Task<Guid> Handle(AddVehiclePositionCommand request, CancellationToken cancellationToken)
    {
        var position = new VehiclePosition(
            Guid.NewGuid(),
            request.VehicleId,
            request.Position,
            request.Timestamp
        );

        await db.VehiclePositions.AddAsync(position, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return position.Id;
    }
}
