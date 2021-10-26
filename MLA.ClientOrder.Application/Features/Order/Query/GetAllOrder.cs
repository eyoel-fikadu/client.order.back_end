using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query
{
    public class GetAllOrder
    {
        public class GetAllOrderCommand : IRequest<List<OrderViewModel>>
        {
            
        }

        public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderCommand, List<OrderViewModel>>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public GetAllOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<OrderViewModel>> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
            {
                var orders = await context.Orders.Include(x => x.Client).Include(x => x.LeadLayer).Include(x => x.OtherLayers)
                   .OrderByDescending(x => x.StartedDate).ToListAsync();

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
}
