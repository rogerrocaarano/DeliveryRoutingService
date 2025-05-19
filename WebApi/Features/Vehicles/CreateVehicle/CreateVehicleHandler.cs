using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.CreateVehicle;

public class CreateVehicleHandler(ServiceDbContext db) : IRequestHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle
        {
            Id = request.VehicleId,
            Capacity = request.Capacity
        };

        await db.Vehicles.AddAsync(vehicle, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return vehicle.Id;
    }
}
