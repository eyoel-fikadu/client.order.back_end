using MLA.ClientOrder.Application.Model;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);
        
        Task<bool> IsRoleExistAsync(string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password, string role);

        Task<Result> DeleteUserAsync(string userId);

        Task<bool> IsEmailOrUserNameValid(string email, string userName);
    }
}
