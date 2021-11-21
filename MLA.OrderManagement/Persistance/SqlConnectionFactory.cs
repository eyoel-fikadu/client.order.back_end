using MLA.ClientOrder.Application.Common.Abstraction;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MLA.OrderManagement.Infrustructure.Persistance
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IDbConnection GetOpenConnection()
        {
            if(_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }
    }
}
