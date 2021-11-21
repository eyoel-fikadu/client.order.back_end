using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Lookup.Command.AddFirm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLA.ClientOrder.API.Controllers
{
    public class LookupController : ApiControllerBase
    {
        [HttpPost("AddFirm")]
        public async Task<ActionResult<Guid>> AddFirm(AddJudCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("AddJud")]
        public async Task<ActionResult<Guid>> AddJud(AddJudCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
