using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Lookup.Command.AddFirm;
using MLA.ClientOrder.Application.Features.Lookup.Command.AddJud;
using MLA.ClientOrder.Application.Features.Lookup.Query;
using MLA.ClientOrder.Application.Features.Lookup.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLA.ClientOrder.API.Controllers
{
    [AllowAnonymous]
    public class LookupController : ApiControllerBase
    {
        [HttpPost("AddFirm")]
        public async Task<ActionResult<Guid>> AddFirm(AddFirmCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("AddJud")]
        public async Task<ActionResult<Guid>> AddJud(AddJudCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("GetLookUps")]
        public async Task<ActionResult<List<LookupsViewModel>>> GetLookups()
        {
            return await Mediator.Send(new GetLookupQueries() { });
        }
    }
}
