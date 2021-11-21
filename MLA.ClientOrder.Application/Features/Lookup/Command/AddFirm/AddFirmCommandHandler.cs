using AutoMapper;
using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Lookup.Command.AddFirm
{
    public class AddFirmCommandHandler : IRequestHandler<AddJudCommand, Guid>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public AddFirmCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(AddJudCommand request, CancellationToken cancellationToken)
        {
            Lookups lookup = new Lookups() { Name = request.Name, Type = Domain.Enums.LookupEnums.LawFirm };
            await context.Lookups.AddAsync(lookup);
            return lookup.Id;
        }
    }
}
