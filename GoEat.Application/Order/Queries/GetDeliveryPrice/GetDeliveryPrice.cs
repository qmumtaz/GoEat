using MediatR;

namespace GoEat.Application.Order.Queries.GetDeliveryPrice;

public class GetDeliveryPrice : IRequest<decimal?>
{
    public Guid OrderId { get; set; }
}
