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

namespace MLA.ClientOrder.Application.Features.Lookup.Command.AddFirm
{
    public class AddFirmCommandHandler : IRequestHandler<AddFirmCommand, Guid>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public AddFirmCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(AddFirmCommand request, CancellationToken cancellationToken)
        {
            Lookups lookup = new Lookups() { Name = request.Name, Type = LookupEnums.LawFirm };
            context.Lookups.Add(lookup);
            await context.SaveChangesAsync(cancellationToken);
            return lookup.Id;
        }
    }
}
