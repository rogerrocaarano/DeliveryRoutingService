namespace WebApi.Domain;

public record VehiclePosition(
    Guid Id,
    Guid VehicleId,
    Coordinates Position,
    DateTime Timestamp
);