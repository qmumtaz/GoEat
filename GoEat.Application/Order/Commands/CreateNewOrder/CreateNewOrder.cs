using MediatR;

namespace GoEat.Application.Order.Commands;

public class CreateNewOrder : IRequest<Guid>
{
    //TODO: minimum order quanitty comes from the datatbase. implement this.

    public decimal MinmimOrderQuantity { get; }

    public CreateNewOrder(decimal minmimOrderQuantity)
    {
        MinmimOrderQuantity = minmimOrderQuantity;
    }
}
