using MediatR;
using WebApi.Domain;
using WebApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Features.Vehicles.RegisterVehiclePosition;

public class GetVehiclePositionsHandler(ServiceDbContext db) : IRequestHandler<GetVehiclePositionsQuery, List<VehiclePosition>>
{
    public async Task<List<VehiclePosition>> Handle(GetVehiclePositionsQuery request, CancellationToken cancellationToken)
    {
        return await db.VehiclePositions
            .Where(vp => vp.VehicleId == request.VehicleId)
            .OrderBy(vp => vp.Timestamp)
            .ToListAsync(cancellationToken);
    }
}
