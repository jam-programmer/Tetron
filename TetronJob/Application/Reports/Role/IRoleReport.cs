using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reports.Role
{
    public interface IRoleReport
    {
        Task<RoleEntity?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellation);
        Task<RoleEntity?> GetRoleByNameAsync(string name, CancellationToken cancellation);
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);
     
       Task<IEnumerable<RoleEntity>> GetRolesAsync(CancellationToken cancellationToken = default);
    }
}
