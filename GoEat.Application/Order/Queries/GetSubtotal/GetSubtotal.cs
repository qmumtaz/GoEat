using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Application.Order.Queries.GetSubtotal
{
    public class GetSubtotal : IRequest<decimal?>
    {
        public Guid Id { get; set; }
    }
}
