using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaEscolar.Core.Repositorys.Base
{
    public static class DbConnectionFactory
    {
        public static IDbConnection CreateConnection()
        {
            var connStr = ConfigurationManager.ConnectionStrings["DbConnStr"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
