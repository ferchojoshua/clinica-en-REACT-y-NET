using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Clinical.Infraestructure.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ClinicaConection")!;
        }
        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
