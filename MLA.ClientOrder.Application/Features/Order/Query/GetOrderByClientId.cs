using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query
{
    public class GetOrderByClientId
    {
        public class GetOrderByClientIdCommand : IRequest<List<OrderViewModel>>
        {
            public Guid guid { get; set; }
        }

        public class GetOrderByClientIdCommandHandler : IRequestHandler<GetOrderByClientIdCommand, List<OrderViewModel>>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public GetOrderByClientIdCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<OrderViewModel>> Handle(GetOrderByClientIdCommand request, CancellationToken cancellationToken)
            {
                var orders = await context.Orders
                    .Include(x => x.Client)
                    .Include(x => x.LeadLayer)
                    .Include(x => x.AdditionalLawyers)
                    .Include(x => x.CrossJudiciaries).ThenInclude(x => x.Judiciaries)
                    .Include(x => x.LawFirmInvolved).ThenInclude(x => x.LawFirm)
                    .Where(x => x.Client.Id == request.guid).ToListAsync();
                var result = new List<OrderViewModel>();
                var listLookups = await context.Lookups.ToListAsync();

                orders.ForEach(order =>
                {
                    var view = new OrderViewModel(order, mapper, listLookups);
                    result.Add(mapper.Map(order, view));
                });
                
                return result;
            }
        }
    }
}
