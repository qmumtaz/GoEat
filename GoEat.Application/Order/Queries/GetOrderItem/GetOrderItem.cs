using GoEat.Logic.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Application.Order.Queries.GetOrderItem
{
    public class GetOrderItem : IRequest<OrderItem?>
    {
        public Guid Id { get; set; }
    }
}
