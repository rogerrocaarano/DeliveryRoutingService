using GraphHopperClient.DTOs;
using GraphHopperClient.Entities;
using WebApi.Domain;
using Vehicle = WebApi.Domain.Vehicle;

namespace WebApi.Extensions.GraphHopper;

public static class RequestBuilder
{
    public static VrpRequest BuildRequest(DeliveryRoute route, Vehicle vehicle, List<DeliveryOrder> orders)
    {
        var ghStartingAddress = BuildStartingAddress(route);
        var ghVehicle = BuildVehicle(vehicle, ghStartingAddress);
        var services = BuildServicesList(orders);
        var objective = new GraphHopperClient.Entities.Objective()
        {
            Type = "min",
            Value = "completion_time"
        };

        return new VrpRequest()
        {
            Vehicles = [ghVehicle],
            Objectives = [objective],
            Services = services
        };
    }

    private static GraphHopperClient.Entities.Address BuildStartingAddress(DeliveryRoute route)
    {
        return new GraphHopperClient.Entities.Address()
        {
            Latitude = route.StartingPoint.Latitude,
            Longitude = route.StartingPoint.Longitude,
            LocationId = route.Id.ToString()
        };
    }

    private static GraphHopperClient.Entities.Vehicle BuildVehicle(
        Vehicle vehicle,
        GraphHopperClient.Entities.Address startAddress
    )
    {
        return new GraphHopperClient.Entities.Vehicle()
        {
            ReturnToDepot = true,
            StartAddress = startAddress,
            VehicleId = vehicle.Id.ToString()
        };
    }

    private static List<GraphHopperClient.Entities.Service> BuildServicesList(List<DeliveryOrder> orders)
    {
        return orders.Select(order => new GraphHopperClient.Entities.Service()
        {
            Id = order.Id.ToString(),
            Type = "service",
            Priority = 2,
            Address = new Address()
            {
                Latitude = order.DeliveryPoint.Latitude,
                Longitude = order.DeliveryPoint.Longitude,
                LocationId = "loc-" + order.Id
            },
            Duration = 600,
            PreparationTime = 0
        }).ToList();
    }
}