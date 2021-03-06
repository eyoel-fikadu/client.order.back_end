using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Application.View_Models;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query
{
    public class GetOrderById
    {
        public class GetOrderByIdCommand : IRequest<OrderViewModel>
        {
            public Guid guid { get; set; }
        }

        public class GetOrderByIdCommandHandler : IRequestHandler<GetOrderByIdCommand, OrderViewModel>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public GetOrderByIdCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<OrderViewModel> Handle(GetOrderByIdCommand request, CancellationToken cancellationToken)
            {
                var order = await context.Orders
                    .Include(x => x.Client)
                    .Include(x => x.LeadLayer)
                    .Include(x => x.AdditionalLawyers)
                    .Include(x => x.CrossJudiciaries).ThenInclude(x => x.Judiciaries)
                    .Include(x => x.LawFirmInvolved).ThenInclude(x => x.LawFirm)
                    .FirstOrDefaultAsync(x => x.Id == request.guid);
                if (order == null) throw new NotFoundException(nameof(Orders), request.guid);
                var listLookups = await context.Lookups.ToListAsync();

                var view = new OrderViewModel(order, mapper, listLookups, context.Lawyers.ToList());
                mapper.Map(order, view);
                return view;
            }
        }
    }
}
