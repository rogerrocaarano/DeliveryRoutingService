using MediatR;

namespace WebApi.Features.Vehicles.VehicleTracking;

public static class VehicleTrackingEndpoints
{
    private const string EndpointName = "vehicles/tracking";

    public static void MapVehicleTrackingEndpoints(this WebApplication app)
    {
        app.MapGet($"/{EndpointName}/{{vehicleId:guid}}/positions", async (Guid vehicleId, ISender sender) =>
        {
            var positions = await sender.Send(new GetVehiclePositionsQuery(vehicleId));
            return Results.Ok(positions);
        });

        app.MapPost($"/{EndpointName}/{{vehicleId:guid}}/positions", async (Guid vehicleId, AddVehiclePositionCommand command, ISender sender) =>
        {
            command = command with { VehicleId = vehicleId };
            var id = await sender.Send(command);
            return Results.Created($"/{EndpointName}/{vehicleId}/positions/{id}", id);
        });
    }
}
