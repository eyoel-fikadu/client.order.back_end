using MediatR;
using MLA.ClientOrder.Application.Features.User.ViewModel;

namespace MLA.ClientOrder.Application.Features.User.AuthorizeUser
{
    public class AuthorizeUserCommand : IRequest<UserViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
