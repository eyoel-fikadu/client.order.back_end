using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Command
{
    public class UpdateClient
    {
        public class UpdateClinetCommand : IRequest
        {
            public Guid guid { get; set; }
        }

        public class UpdateClinetCommandHandler : IRequestHandler<UpdateClinetCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateClinetCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateClinetCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Clients.FindAsync(request.guid);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Clients), request.guid);
                }

                //entity. = request.Title;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
