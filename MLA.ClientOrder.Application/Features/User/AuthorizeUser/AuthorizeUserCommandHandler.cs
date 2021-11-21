using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Features.User.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.User.AuthorizeUser
{
    public class AuthorizeUserCommandHandler : IRequestHandler<AuthorizeUserCommand, UserViewModel>
    {
        private readonly IApplicationDbContext _context;
        //private readonly ITokenService _token;
        private readonly IIdentityService _identity;

        public AuthorizeUserCommandHandler(IApplicationDbContext context, IIdentityService identity)// ITokenService token, 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //_token = token ?? throw new ArgumentNullException(nameof(token));
            _identity = identity ?? throw new ArgumentNullException(nameof(identity));
        }

        public async Task<UserViewModel> Handle(AuthorizeUserCommand request, CancellationToken cancellationToken)
        {
            return await _identity.AuthorizeUserAsync(request.UserName, request.Password);
        }
    }
}
