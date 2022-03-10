using MediatR;

namespace GoEat.Application.Order.Commands.AddDiscount
{
    public class AddDiscountHandler : IRequestHandler<AddDiscount, decimal>
    {
        public Task<decimal> Handle(AddDiscount request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
