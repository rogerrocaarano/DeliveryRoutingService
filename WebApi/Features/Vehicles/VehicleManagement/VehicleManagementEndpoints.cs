using MediatR;

namespace WebApi.Features.Vehicles.VehicleManagement;

public static class VehicleManagementEndpoints
{
    private const string EndpointName = "vehicles";

    public static void MapVehicleManagementEndpoints(this WebApplication app)
    {
        app.MapPost($"/{EndpointName}/add", async (AddVehicleCommand command, ISender sender) =>
        {
            var id = await sender.Send(command);
            return Results.Created($"/{EndpointName}/{id}", id);
        });

        app.MapDelete($"/{EndpointName}/{{vehicleId:guid}}", async (Guid vehicleId, ISender sender) =>
        {
            await sender.Send(new DeleteVehicleCommand(vehicleId));
            return Results.NoContent();
        });
    }
}
