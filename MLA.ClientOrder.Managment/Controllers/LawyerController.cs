using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Lawyer.Command;
using MLA.ClientOrder.Application.Features.Layer.Command;
using MLA.ClientOrder.Application.Features.Layer.Dto;
using MLA.ClientOrder.Application.Features.Layer.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLA.ClientOrder.API.Controllers
{
    public class LawyerController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<LawyersDto>>> GetAllLawyers()
        {
            return await Mediator.Send(new GetAllLawyersCommand());
        }

        //[HttpGet("{guid}")]
        //public async Task<ActionResult<LawyersDto>> GetLawyerById(Guid guid)
        //{
        //    return await Mediator.Send(new GetLawyerCommand() { guid = guid });
        //}

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddLawyerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("UpdateLawyerTable")]
        public async Task<ActionResult<bool>> UpdateLawyerFromExsitingDb()
        {
            return await Mediator.Send(new UpdateLawyerTableCommand());
        }
    }
}
