using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reports.Role
{
    public interface IRoleReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);
    }
}
