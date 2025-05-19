using MediatR;
using WebApi.Domain;
using WebApi.Domain.Enums;
using WebApi.Persistence;

namespace WebApi.Features.Delivery.OrderManagement;

public class AddOrderHandler(ServiceDbContext db) : IRequestHandler<AddOrderCommand, Guid>
{
    public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new DeliveryOrder
        {
            DeliveryPoint = request.DeliveryPoint,
            Id = request.OrderId,
            UpdateTimeStamp = DateTime.UtcNow,
            Volume = request.Volume,
            Status = OrderStatus.WaitingForRoute
        };
        
        try
        {
            await db.Orders.AddAsync(order, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}