using MediatR;
using Microsoft.Extensions.Logging;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.User.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IIdentityService _identity;
        private readonly ILogger<AddUserCommandHandler> _logger;
        private readonly IApplicationDbContext _context;

        public AddUserCommandHandler(IIdentityService identity, ILogger<AddUserCommandHandler> logger, IApplicationDbContext context)
        {
            _identity = identity ?? throw new ArgumentNullException(nameof(identity));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identity.CreateUserAsync(request.UserName, request.Email, request.Password, request.Role);

            UserDetails userDetail = new UserDetails 
            {
                UserId = result.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _context.Users.Add(userDetail);
            await _context.SaveChangesAsync(cancellationToken);
            return userDetail.Id;
        }
    }
}
