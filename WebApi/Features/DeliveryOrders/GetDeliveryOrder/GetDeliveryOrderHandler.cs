using MediatR;
using WebApi.Persistence;
using WebApi.Domain;

namespace WebApi.Features.DeliveryOrders.GetDeliveryOrder;

public class GetDeliveryOrderHandler(ServiceDbContext db) : IRequestHandler<GetDeliveryOrderCommand, DeliveryOrder>
{
    public async Task<DeliveryOrder> Handle(GetDeliveryOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await db.Orders.FindAsync([request.OrderId], cancellationToken);
        if (order == null)
        {
            throw new Exception($"Order with ID {request.OrderId} not found.");
        }

        return order;
    }
}