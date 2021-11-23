using AutoMapper;
using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Lookup.Command.AddJud
{
    public class AddJudCommandHandler : IRequestHandler<AddJudCommand, Guid>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public AddJudCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(AddJudCommand request, CancellationToken cancellationToken)
        {
            Lookups lookup = new Lookups() { Name = request.Name, Type = LookupEnums.CrossJudiciary };
            
            context.Lookups.Add(lookup);
            await context.SaveChangesAsync(cancellationToken);
            return lookup.Id;
        }
    }
}
