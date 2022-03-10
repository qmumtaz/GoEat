using GoEat.Logic.Order.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Application.Order.Commands.UpdateOrderItem
{
    public class UpdateOrderQuantity : IRequest<int?>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

    }
}
