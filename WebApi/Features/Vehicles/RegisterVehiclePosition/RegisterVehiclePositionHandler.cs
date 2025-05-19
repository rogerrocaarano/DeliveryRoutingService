using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.RegisterVehiclePosition;

public class RegisterVehiclePositionHandler(ServiceDbContext db) : IRequestHandler<RegisterVehiclePositionCommand, Guid>
{
    public async Task<Guid> Handle(RegisterVehiclePositionCommand request, CancellationToken cancellationToken)
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
