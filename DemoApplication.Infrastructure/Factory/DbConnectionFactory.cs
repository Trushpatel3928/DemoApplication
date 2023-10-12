using DemoApplication.Core.Abstraction.Factory;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DemoApplication.Infrastructure.Factory
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration configuration;
        public DbConnectionFactory(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public virtual IDbConnection GetConnection()
        {
            return new SqlConnection(configuration["SetupDB"]);
        }
    }
}
