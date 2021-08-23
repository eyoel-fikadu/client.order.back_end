using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using MLA.ClientOrder.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Command
{
    public class AddOrder
    {
        public class AddOrderCommand : IRequest<Guid>, IMapTo<Orders>
        {
            public string IdustrySector { get; set; }
            public Guid LeadLayerId { get; set; }
            public Guid ClientId { get; set; }
            public List<Guid> OtherLayers { get; set; }
            public bool IsLawFirmInvolved { get; set; }
            public bool CroossJudiciaryExistt { get; set; }
            public List<LawFirmDto> LawFirmInvolved { get; set; }
            public List<string> CrossJudiciaries { get; set; }
            public string TransactionType { get; set; }
            public string TransactionDescription { get; set; }
            public string MatterDescription { get; set; }
            public double TransactionValue { get; set; }
            public bool IsConfidential { get; set; }
            public string ProjectStatus { get; set; }
            public string Remark { get; set; }
            public DateTime CompletedDate { get; set; }
            public DateTime StartedDate { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<AddOrderCommand, Orders>()
                    .ForMember(d => d.CrossJudiciaries, opt => opt.Ignore())
                    .ForMember(d => d.LeadLayer, opt => opt.Ignore())
                    .ForMember(d => d.OtherLayers, opt => opt.Ignore())
                    .ForMember(d => d.LawFirmInvolved, opt => opt.Ignore());
            }
        }

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
                var order = mapper.Map<Orders>(request);
                order.LawFirmInvolved = new List<LawFirmInvolved>();
                request?.LawFirmInvolved.ForEach( x => order.LawFirmInvolved.Add(mapper.Map<LawFirmInvolved>(x)));
                order.LeadLayer = await context.Layers.FindAsync(request.LeadLayerId);
                order.Client = await context.Clients.FindAsync(request.ClientId);
                order.OtherLayers = await context.Layers.Where(x => request.OtherLayers.Contains(x.Id)).ToListAsync();
                order.CrossJudiciaries = new List<CrossJudiciaries>();
                request?.CrossJudiciaries.ForEach(x => order.CrossJudiciaries.Add(new CrossJudiciaries(x)));
                context.Orders.Add(order);
                await context.SaveChangesAsync(cancellationToken);
                return order.Id;
            }
        }
    }

    public class LawFirmDto : IMapTo<LawFirmInvolved>, IMapFrom<LawFirmInvolved>
    {
        public string LawFirm { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LawFirmDto, LawFirmInvolved>();
            profile.CreateMap<List<LawFirmDto>, List<LawFirmInvolved>>();

            profile.CreateMap<LawFirmInvolved, LawFirmDto>();
            profile.CreateMap<List<LawFirmInvolved>, List<LawFirmDto>>();
        }

    }
}
