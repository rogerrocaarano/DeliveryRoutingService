using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.VehicleRegistration;

public class AddVehicleHandler(ServiceDbContext db) : IRequestHandler<AddVehicleCommand, Guid>
{
    public async Task<Guid> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
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
