using GoEat.Infrastructure.Context;
using GoEat.Logic.Order.Factories;
using MediatR;

namespace GoEat.Application.Order.Commands.DeleteOrderItem;

public class DeleteOrderItemHandler : IRequestHandler<DeleteOrderItem, int>
{
    private readonly OrderContext _context;

    public DeleteOrderItemHandler(OrderContext context )
    {
       _context = context;
        
    }

    public Task<int> Handle(DeleteOrderItem request, CancellationToken cancellationToken)
    {
        
        var item = _context.Remove(request.Id);
        var orderamount = request.OrderAmount;
        return null;
    }

}
