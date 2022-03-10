using GoEat.Application.Order.Commands.UpdateOrderItem;
using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order.ValueObjects;
using MediatR;

namespace GoEat.Application.Order.Commands.UpdateOrderItemQuantity
{
    public class UpdateOrderQuantityHandler : IRequestHandler<UpdateOrderQuantity, int?>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderQuantityHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int?> Handle(UpdateOrderQuantity request, CancellationToken cancellationToken)
        {
            var getorder = await _orderRepository.GetOrderItem(new Id(request.Id));

            if (getorder == null)
            {
                return null;
            }

            return request.Quantity;
        }
    }
}
