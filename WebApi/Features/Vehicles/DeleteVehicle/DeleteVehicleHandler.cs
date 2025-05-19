using MediatR;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleHandler(ServiceDbContext db) : IRequestHandler<DeleteVehicleCommand>
{
    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await db.Vehicles.FindAsync([request.VehicleId], cancellationToken);
        if (vehicle == null)
            throw new Exception($"Vehicle with ID {request.VehicleId} not found.");

        db.Vehicles.Remove(vehicle);
        await db.SaveChangesAsync(cancellationToken);
    }
}
