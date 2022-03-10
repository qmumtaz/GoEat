using MediatR;


namespace GoEat.Application.Order.Commands.DeleteOrderItem;

public class DeleteOrderItem : IRequest<int>
{
    public Guid Id { get; set; }
    public int OrderAmount { get; set; }
}
