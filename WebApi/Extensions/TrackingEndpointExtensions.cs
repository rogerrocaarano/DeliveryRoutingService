using MediatR;

namespace WebApi.Extensions;

public static class TrackingEndpointExtensions
{
    public static void MapTrackingEndpoints(this WebApplication app)
    {
        app.MapGet("/tracking/vehicles/{vehicleId}/positions", async (Guid vehicleId, ISender sender) =>
        {
            // Aquí puedes implementar la lógica para obtener las posiciones del vehículo.
            // Por ejemplo, enviar un comando o consulta al mediador.
            return Results.Ok(); // Devuelve un resultado de ejemplo.
        });

        app.MapPost("/tracking/vehicles/{vehicleId}/positions", async (Guid vehicleId, object positionData, ISender sender) =>
        {
            // Aquí puedes implementar la lógica para registrar una nueva posición del vehículo.
            // Por ejemplo, enviar un comando al mediador.
            return Results.NoContent(); // Devuelve un resultado de ejemplo.
        });
    }
}
