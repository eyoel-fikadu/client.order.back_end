using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using MLA.ClientOrder.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            List<Lookups> lookupsList = _context.Lookups.ToList();
            var entity = await _context.Orders.FindAsync(request.id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Orders), request.id);
            }
            _mapper.Map(request, entity);
            entity.LawFirmInvolved = new List<LawFirmInvolved>();
            request?.LawFirmInvolved.ForEach(x => entity.LawFirmInvolved.Add(_mapper.Map<LawFirmInvolved>(x)));
            entity.LeadLayer = await _context.Lawyers.FindAsync(request.LeadLayerId);
            entity.Client = await _context.Clients.FindAsync(request.ClientId);
            var lawyers = await _context.Lawyers.Where(x => request.OtherLayers.Contains(x.Id)).ToListAsync();
            entity.OtherLawyers = new List<OtherLawyers>();
            lawyers.ForEach(x =>
            {
                entity.OtherLawyers.Add(new OtherLawyers() { Order = entity, Lawyer = x });
            });
            entity.CrossJudiciaries = new List<CrossJudiciaries>();

            request?.CrossJudiciaries.ForEach(x => entity.CrossJudiciaries.Add(new CrossJudiciaries() { Judiciaries = lookupsList.FirstOrDefault(y => y.Id == x) }));

            _context.Orders.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
