using MediatR;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Query.FilterOrder
{
    public class FilterOrderQuery : IRequest<List<OrderViewModel>>
    {
        public Guid ClientId { get; set; }
        public bool? IsCompleted { get; set; }
        public Guid LeadLawyerId { get; set; }
        public Guid LawFirmInvolved { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
