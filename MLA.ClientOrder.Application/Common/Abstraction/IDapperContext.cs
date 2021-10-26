using MLA.ClientOrder.Domain.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface IDapperContext
    {
        public Task<List<OrderDbModel>> GetOrders();
    }
}
