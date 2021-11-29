using MediatR;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Query.GetAllOrdes
{
    public class GetAllOrderCommand : IRequest<List<OrderViewModel>>
    {

    }
}
