using MediatR;

namespace GoEat.Application.Order.Queries;

public class GetTotal : IRequest<decimal?>
{
    public GetTotal(Guid id)
    {
        OrderId = id;
    }

    public Guid OrderId { get; set; }
}