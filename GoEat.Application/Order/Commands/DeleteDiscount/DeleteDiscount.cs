using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoEat.Application.Order.Commands.DeleteDiscount
{
    public class DeleteDiscount :  IRequest<Guid>
    {
        public decimal discount { get; set; }
        public Guid Id { get; set; }
    }
}
