using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.User.AddUser;
using System;
using System.Threading.Tasks;

namespace MLA.ClientOrder.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser(AddUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
