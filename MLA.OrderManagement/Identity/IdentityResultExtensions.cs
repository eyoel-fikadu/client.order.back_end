using Microsoft.AspNetCore.Identity;
using MLA.ClientOrder.Application.Model;
using System.Linq;

namespace MLA.OrderManagement.Infrustructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
