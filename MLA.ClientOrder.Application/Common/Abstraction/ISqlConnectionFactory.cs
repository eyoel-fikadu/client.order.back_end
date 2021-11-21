using System.Data;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
