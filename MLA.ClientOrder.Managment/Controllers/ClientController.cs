using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Client.Command;
using MLA.ClientOrder.Application.Features.Client.Query.FilterClient;
using MLA.ClientOrder.Application.Features.Client.Query.GetAllClient;
using MLA.ClientOrder.Application.Features.Client.Query.GetAllClinetNonPaginated;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MLA.ClientOrder.Application.Features.Client.Command.UpdateClient;
using static MLA.ClientOrder.Application.Features.Client.Query.GetClient;

namespace MLA.ClientOrder.API.Controllers
{
    public class ClientController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ClientViewModel>>> GetClientsWithPagination([FromQuery] GetAllClientPaginatedCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("listAll")]
        public async Task<ActionResult<List<ClientViewModel>>> GetClientsList()
        {
            return await Mediator.Send(new GetAllClientQuery());
        }

        [HttpGet("getByFilter")]
        public async Task<ActionResult<List<ClientViewModel>>> GetClientsByFilter([FromQuery] FilterClientQuery query)
        {
            return await Mediator.Send(query);

        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<ClientViewModel>> GetClientById(Guid guid)
        {
            return await Mediator.Send(new GetClientCommand() { guid = guid });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddClientCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateClinetCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> MakeInActive(Guid id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return NoContent();
        }
    }
}
