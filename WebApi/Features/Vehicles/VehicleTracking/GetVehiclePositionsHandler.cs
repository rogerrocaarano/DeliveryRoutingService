using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Vehicles.VehicleTracking;

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
