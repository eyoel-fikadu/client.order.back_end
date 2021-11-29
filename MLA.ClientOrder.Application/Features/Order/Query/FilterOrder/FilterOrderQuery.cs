using MediatR;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Query.FilterOrder
{
    public class FilterOrderQuery : IRequest<List<OrderViewModel>>
    {
        public Guid ClientId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
