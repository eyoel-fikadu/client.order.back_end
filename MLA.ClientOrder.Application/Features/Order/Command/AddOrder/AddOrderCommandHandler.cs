using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using MLA.ClientOrder.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Command.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public AddOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            List<Lookups> lookupsList = context.Lookups.ToList();
            var order = mapper.Map<Orders>(request);
            order.LawFirmInvolved = new List<LawFirmInvolved>();
            request?.LawFirmInvolved.ForEach(x => order.LawFirmInvolved.Add(mapper.Map<LawFirmInvolved>(x)));
            order.LeadLayer = await context.Lawyers.FindAsync(request.LeadLayerId);
            order.Client = await context.Clients.FindAsync(request.ClientId);
            var lawyers = await context.Lawyers.Where(x => request.OtherLayers.Contains(x.Id)).ToListAsync();
            order.OtherLawyers = new List<OtherLawyers>();
            lawyers.ForEach(x =>
            {
                order.OtherLawyers.Add(new OtherLawyers() { Order = order, Lawyer = x });
            });
            order.CrossJudiciaries = new List<CrossJudiciaries>();
            
            request?.CrossJudiciaries.ForEach(x => order.CrossJudiciaries.Add(new CrossJudiciaries() { Judiciaries = lookupsList.FirstOrDefault(y => y.Id == x) }));
            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
