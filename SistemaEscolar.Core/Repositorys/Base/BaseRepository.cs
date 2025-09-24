using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys.Base
{
    public class BaseRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;

        public BaseRepository()
        {
            _connection = DbConnectionFactory.CreateConnection();
        }

        public async Task<IEnumerable<T>> QueryAsync(string sql, object param = null)
        {
            return await _connection.QueryAsync<T>(sql, param);
        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object param = null)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await _connection.ExecuteAsync(sql, param);
        }
    }
}
