using IdentityModel.Client;
using MLA.ClientOrder.Application.Features.User.ViewModel;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface ITokenService
    {
        public string BuildToken(UserViewModel user);
        Task<TokenResponse> GetToken(string scope);
    }
}
