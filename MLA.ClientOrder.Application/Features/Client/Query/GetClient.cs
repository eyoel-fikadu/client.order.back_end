using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Application.View_Models;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Query
{
    public class GetClient
    {
        public class GetClientCommand : IRequest<ClientViewModel>
        {
            public Guid guid { get; set; }
        }

        public class GetClientHandler : IRequestHandler<GetClientCommand, ClientViewModel>
        {
            private readonly IApplicationDbContext context;

            public GetClientHandler(IApplicationDbContext context)
            {
                this.context = context;
            }
            public async Task<ClientViewModel> Handle(GetClientCommand request, CancellationToken cancellationToken)
            {
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == request.guid);
                if (client == null) throw new NotFoundException(nameof(Clients), request.guid.ToString());

                return new ClientViewModel(client);
            }
        }
    }
}
