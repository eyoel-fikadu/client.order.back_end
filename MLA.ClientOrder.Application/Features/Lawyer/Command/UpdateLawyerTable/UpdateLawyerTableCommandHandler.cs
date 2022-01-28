using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Lawyer.Command.UpdateLawyerTable
{
    public class UpdateLawyerTableCommandHandler : IRequestHandler<UpdateLawyerTableCommand, bool>
    {
        private readonly IDapperContext _dapperContext;
        private readonly IApplicationDbContext _context;

        public UpdateLawyerTableCommandHandler(IDapperContext dapperContext, IApplicationDbContext context)
        {
            _dapperContext=dapperContext??throw new ArgumentNullException(nameof(dapperContext));
            _context=context??throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(UpdateLawyerTableCommand request, CancellationToken cancellationToken)
        {
            var lawyers = await _dapperContext.GetLawyers();
            foreach(var lawyer in lawyers)
            {
                var ly = await _context.Lawyers.FirstOrDefaultAsync(x => x.UserName.ToLower().Trim().Equals(lawyer.UserId.ToLower().Trim()));
                if (ly == null)
                {
                    await _context.Lawyers.AddAsync(new Domain.Entities.Lawyers()
                    {
                        Department = lawyer.Department,
                        FirstName = lawyer.Name,
                        LastName = lawyer.LastName,
                        Role = "",
                        Title = lawyer.Title,
                        UserName = lawyer.UserId
                    });
                }
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
