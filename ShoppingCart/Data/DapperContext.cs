using Microsoft.Extensions.Configuration; 
using System.Data;
using System.Data.SqlClient; 

namespace ShoppingCart.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
    }
}
