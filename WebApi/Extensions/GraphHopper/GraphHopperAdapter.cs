using WebApi.Domain;

namespace WebApi.Extensions.GraphHopper;

public class GraphHopperAdapter(GraphHopperClient.GraphHopperClient client)
{
    public async Task<List<Guid>> GetOptimizedRoute(DeliveryRoute route, Vehicle vehicle, List<DeliveryOrder> orders)
    {
        var request = RequestBuilder.BuildRequest(route, vehicle, orders);
        var response = await client.Vrp(request);

        if (response == null)
        {
            return [];
        }

        return response.Solution.Routes.First().Activities
            .Where(activity => activity.Type == "service")
            .Select(activity => Guid.Parse(activity.Id))
            .ToList();
    }
}