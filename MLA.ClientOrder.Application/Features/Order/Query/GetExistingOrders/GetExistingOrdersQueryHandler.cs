using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query.GetExistingOrders
{
    public class GetExistingOrdersQueryHandler : IRequestHandler<GetExistingOrdersQuery, List<OrderDbModel>>
    {
        private readonly IDapperContext _dapper;

        public GetExistingOrdersQueryHandler(IDapperContext dapper)
        {
            _dapper = dapper ?? throw new ArgumentNullException(nameof(dapper));
        }

        public Task<List<OrderDbModel>> Handle(GetExistingOrdersQuery request, CancellationToken cancellationToken)
        {
            return _dapper.GetOrders();
        }
    }
}
