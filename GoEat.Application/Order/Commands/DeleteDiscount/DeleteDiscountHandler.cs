using GoEat.Infrastructure.Context;
using MediatR;


namespace GoEat.Application.Order.Commands.DeleteDiscount
{
    public class DeleteDiscountHandler : IRequestHandler<DeleteDiscount, Guid>
    {
        private readonly OrderContext orderContext;

        public DeleteDiscountHandler(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }


        Task<Guid> IRequestHandler<DeleteDiscount, Guid>.Handle(DeleteDiscount request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var discount = new Order();
        }
    }
}
