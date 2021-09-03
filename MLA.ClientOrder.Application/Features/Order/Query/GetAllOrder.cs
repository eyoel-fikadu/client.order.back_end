using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query
{
    public class GetAllOrder
    {
        public class GetAllOrderCommand : IRequest<PaginatedList<OrderViewModel>>
        {
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10;
        }

        public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderCommand, PaginatedList<OrderViewModel>>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public GetAllOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<PaginatedList<OrderViewModel>> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
            {
                var orders = await context.Orders.Include(x => x.Client).Include(x => x.LeadLayer).Include(x => x.OtherLayers)
                   .OrderByDescending(x => x.StartedDate)
                   .PaginatedListAsync(request.PageNumber, request.PageSize);

                List<OrderViewModel> result = new List<OrderViewModel>();
                orders.Items.ForEach(order =>
                {
                    var view = new OrderViewModel(order, mapper);
                    result.Add(mapper.Map(order, view));
                });

                return new PaginatedList<OrderViewModel>(result, orders.TotalCount, request.PageNumber, request.PageSize);
            }
        }
    }
}
