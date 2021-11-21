using MediatR;
using MLA.ClientOrder.Domain.DbModels;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Query.GetExistingOrders
{
    public class GetExistingOrdersQuery : IRequest<List<OrderDbModel>>
    {
    }
}
