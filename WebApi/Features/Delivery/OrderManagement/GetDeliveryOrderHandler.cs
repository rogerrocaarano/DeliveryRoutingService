using MediatR;
using WebApi.Domain;
using WebApi.Persistence;

namespace WebApi.Features.Delivery.OrderManagement;

public class GetDeliveryOrderHandler(ServiceDbContext db) : IRequestHandler<GetDeliveryOrderQuery, DeliveryOrder>
{
    public async Task<DeliveryOrder> Handle(GetDeliveryOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await db.Orders.FindAsync([request.OrderId], cancellationToken);
        if (order == null)
        {
            throw new Exception($"Order with ID {request.OrderId} not found.");
        }

        return order;
    }
}