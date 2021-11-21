using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Layer.Command
{
    public class AddLawyerCommand : IRequest<Guid>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
    }

    public class AddLawyerHandler : IRequestHandler<AddLawyerCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddLawyerHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddLawyerCommand request, CancellationToken cancellationToken)
        {
            var layer = new Lawyers()
            {
                FirstName = request.firstName,
                LastName = request.lastName,
                Role = request.role
            };

            _context.Lawyers.Add(layer);

            await _context.SaveChangesAsync(cancellationToken);

            return layer.Id;
        }
    }
}
