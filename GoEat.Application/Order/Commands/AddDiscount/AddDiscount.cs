using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Application.Order.Commands.AddDiscount
{
    public class AddDiscount : IRequest<decimal>
    {
    }
}
