using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Client.Command;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MLA.ClientOrder.Application.Features.Client.Command.UpdateClient;
using static MLA.ClientOrder.Application.Features.Client.Query.GetAllClient;
using static MLA.ClientOrder.Application.Features.Client.Query.GetClient;

namespace MLA.ClientOrder.API.Controllers
{
    [Authorize]
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


        [HttpGet("{guid}")]
        public async Task<ActionResult<ClientViewModel>> GetClientById(Guid guid)
        {
            return await Mediator.Send(new GetClientCommand() { guid = guid});
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddClientCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateClinetCommand command)
        {
            if (id != command.guid)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeleteTodoItemCommand { Id = id });

        //    return NoContent();
        //}
    }
}
