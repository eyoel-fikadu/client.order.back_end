using Microsoft.Extensions.Logging;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace MLA.OrderManagement.Infrustructure.Persistance
{
    public class DapperContext : IDapperContext
    {
        private readonly ISqlConnectionFactory _connection;
        private readonly ILogger<DapperContext> _logger;

        public DapperContext(ISqlConnectionFactory connection, ILogger<DapperContext> logger)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<OrderDbModel>> GetOrders()
        {
            var query = "SELECT [MlA_Order_Number] 'OrderId' ,[Clients] 'ClientName' ,[Matter] 'Matter' " +
                "FROM[dbo].[Orders] " +
                "Where[MlA_Order_Number] NOT IN(Select[OrderId] From [NewOrderMgt].[Orders])";
            var orders = await _connection.GetOpenConnection().QueryAsync<OrderDbModel>(query);
            return orders.ToList();
        }
    }
}
