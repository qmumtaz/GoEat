using GoEat.Application.Order.Queries;
using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order.Services;
using GoEat.Logic.Order.ValueObjects;
using MediatR;

namespace GoEat.Application.Order.Handlers;

public class GetTotalHandler : IRequestHandler<GetTotal, decimal?>
{
    private readonly IOrderRepository _repository;
    private readonly IDeliveryCalculator _deliveryCalculator;

    public GetTotalHandler(IOrderRepository repository, IDeliveryCalculator deliveryCalculator)
    {
        _repository = repository;
        _deliveryCalculator = deliveryCalculator;
    }

    public async Task<decimal?> Handle(GetTotal request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetOrder(new Id(request.OrderId), true);

        if (order == null)
        {
            return null;
        }
       
        var (DeliveryPrice, _) = _deliveryCalculator.CalculateDeliveryPrice(order, new Price(10.00M));

        var total =  order.Total(DeliveryPrice);

        return total;
    }
}
