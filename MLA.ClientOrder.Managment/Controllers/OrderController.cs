using Microsoft.AspNetCore.Mvc;
using MLA.ClientOrder.API.Controllers.Common;
using MLA.ClientOrder.Application.Features.Order.Command;
using MLA.ClientOrder.Application.Features.Order.Command.CompleteOrder;
using MLA.ClientOrder.Application.Features.Order.Query;
using MLA.ClientOrder.Application.Features.Order.Query.FilterOrder;
using MLA.ClientOrder.Application.Features.Order.Query.GetAllOrdes;
using MLA.ClientOrder.Application.Features.Order.Query.GetExistingOrders;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using MLA.ClientOrder.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MLA.ClientOrder.Application.Features.Order.Query.GetOrderByClientId;
using static MLA.ClientOrder.Application.Features.Order.Query.GetOrderById;

namespace MLA.ClientOrder.API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderViewModel>>> GetTodoItemsWithPagination()
        {
            return await Mediator.Send(new GetAllOrderCommand());
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

        [HttpPut]
        public async Task<ActionResult> Update(UpdateOrderCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> Update(CompleteOrderCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("getOrderEnums")]
        public async Task<ActionResult<List<EnumResponseModel>>> GetEnums()
        {
            return await Mediator.Send(new GetOrderEnums());
        }

        [HttpGet("getOrderFromOldDb")]
        public async Task<ActionResult<List<OrderDbModel>>> GetExistingOrders()
        {
            return await Mediator.Send(new GetExistingOrdersQuery());
        }

        [HttpGet("getByFilter")]
        public async Task<ActionResult<List<OrderViewModel>>> GetOrdersByFilter([FromQuery] FilterOrderQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
