using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Order.Query;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MLA.ClientOrder.Application.Features.Order.Command.AddOrder;
using static MLA.ClientOrder.Application.Features.Order.Query.GetAllOrder;
using static MLA.ClientOrder.Application.Features.Order.Query.GetOrderByClientId;
using static MLA.ClientOrder.Application.Features.Order.Query.GetOrderById;

namespace MLA.ClientOrder.API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<OrderViewModel>>> GetTodoItemsWithPagination([FromQuery] GetAllOrderCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<OrderViewModel>> GetOderById(Guid guid)
        {
            return await Mediator.Send(new GetOrderByIdCommand() { guid = guid });
        }

        [HttpGet("getByClientId/{guid}")]
        public async Task<ActionResult<List<OrderViewModel>>> GetOderByClientId(Guid guid)
        {
            return await Mediator.Send(new GetOrderByClientIdCommand() { guid = guid });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(Guid id, UpdateClinetCommand command)
        //{
        //    if (id != command.guid)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        [HttpGet("getOrderEnums")]
        public async Task<ActionResult<List<EnumResponseModel>>> GetEnums()
        {
            return await Mediator.Send(new GetOrderEnums());
        }

    }
}
