using MediatR;
using System;

namespace MLA.ClientOrder.Application.Features.Order.Command.CompleteOrder
{
    public class CompleteOrderCommand : IRequest
    {
        public Guid id { get; set; }   
        public DateTime completedDate { get; set; }
    }
}
