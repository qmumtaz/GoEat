using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order.Services;
using MediatR;

namespace GoEat.Application.Order.Queries.GetDeliveryPrice;

public class GetDeliveryPriceHandler : IRequestHandler<GetDeliveryPrice, decimal?>
{
    private readonly IOrderRepository _repository;
    private readonly IDeliveryCalculator _deliveryCalculator;

    public GetDeliveryPriceHandler(IOrderRepository repository, IDeliveryCalculator deliveryCalculator)
    {
        _repository = repository;
        _deliveryCalculator = deliveryCalculator;
    }

    public async Task<decimal?> Handle(GetDeliveryPrice request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetOrder(new Logic.Order.ValueObjects.Id(request.OrderId), true);

        if (order == null)
        {
            return null;
        }

        var (DeliveryPrice, _) = _deliveryCalculator.CalculateDeliveryPrice(order, new Logic.Order.ValueObjects.Price(10M));

        return DeliveryPrice.Value;
    }
}
