using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order.ValueObjects;
using MediatR;

namespace GoEat.Application.Order.Queries.GetSubtotal;

public class GetSubtotalHandler : IRequestHandler<GetSubtotal, decimal?>
{
    private readonly IOrderRepository _repository;

    public GetSubtotalHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<decimal?> Handle(GetSubtotal request, CancellationToken cancellationToken)
    {     
        var order = await _repository.GetOrder(new Id(request.Id));

        if (order == null)
        {
            return null;
        }

        return order.SubTotal; ;
    }
}
