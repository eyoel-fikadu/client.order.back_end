using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query.FilterOrder
{
    public class FilterOrderQueryHandler : IRequestHandler<FilterOrderQuery, List<OrderViewModel>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public FilterOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<OrderViewModel>> Handle(FilterOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders
                .Include(x => x.Client)
                .Include(x => x.LeadLayer)
                .Include(x => x.OtherLawyers).ThenInclude(x => x.Lawyer)
                .Include(x => x.CrossJudiciaries).ThenInclude(x => x.Judiciaries)
                .Include(x => x.LawFirmInvolved).ThenInclude(x => x.LawFirm)
                .OrderByDescending(x => x.StartedDate)
                .ToListAsync();

            orders = orders.Where(x =>
                    x.Client.Id == request.ClientId
                    && x.IsCompleted == request.IsCompleted)
                .ToList();

            List<OrderViewModel> result = new List<OrderViewModel>();
            orders.ForEach(order =>
            {
                var view = new OrderViewModel(order, mapper);
                result.Add(mapper.Map(order, view));
            });

            return result;
        }
    }
}
