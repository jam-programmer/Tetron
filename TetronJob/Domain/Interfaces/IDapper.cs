using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDapper
    {
        Task<List<TEntity>?>ExecuteQuery<TEntity>(string query);
        Task<List<TEntity>> Execute<TEntity>(string storedProcedure, Dictionary<string,string> parmeter);
    }
}
