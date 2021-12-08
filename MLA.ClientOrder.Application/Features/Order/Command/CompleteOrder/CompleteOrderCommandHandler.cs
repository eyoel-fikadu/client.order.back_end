using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Command.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public CompleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Orders), request.id);
            }
            entity.ProjectStatus = "Completed";
            entity.CompletedDate = request.completedDate;
            entity.IsCompleted = true;
            _context.Orders.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
