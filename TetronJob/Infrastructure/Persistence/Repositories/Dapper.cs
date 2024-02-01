using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Interfaces;
using Infrastructure.Common;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Persistence.Repositories
{
    public class Dapper:IDapper
    {
        private readonly SqlConnection _connection;
        public Dapper()
        {
            _connection = new SqlConnection(ConnectionOptions.ConnectionString);
        }

        public async Task<List<TEntity>?> ExecuteQuery<TEntity>(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var model = await _connection.QueryAsync<TEntity>(query);
                return model.ToList();
            }
            return null;
        }

        public async Task<List<TEntity>> Execute<TEntity>(string storedProcedure, Dictionary<string, string> parmeter)
        {
            if (string.IsNullOrEmpty(storedProcedure))
            {

            }
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                foreach (var item in parmeter)
                {
                    parameters.Add(item.Key, item.Value);
                }

                var model = await _connection.QueryAsync<TEntity>(storedProcedure, parameters, 
                    commandType: CommandType.StoredProcedure);
                return model.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

    
        }
    }
}
