using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Role
{
    public class RoleReport : IRoleReport
    {
        private readonly RoleManager<RoleEntity> _roleManager;

        public RoleReport(RoleManager<RoleEntity> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<RoleEntity?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                //todo
            }

            return role;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = _roleManager.Roles.AsNoTracking().AsQueryable();

            //// Apply search filter.
            //if (!string.IsNullOrEmpty(pagination.Keyword))
            //{
            //    query = query
            //        .Where(r => r.Name!.Contains(pagination.Keyword) || r.PersianName!.Contains(pagination.Keyword))
            //        .AsQueryable();
            //}

            return await query.PaginatedListAsync<RoleEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<IEnumerable<RoleEntity>> GetRolesAsync(CancellationToken cancellationToken = default)
        {
            return await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<RoleEntity?> GetRoleByNameAsync(string name, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var role = await _roleManager.FindByNameAsync(name.ToString());
            if (role == null)
            {
                //todo
            }

            return role;
        }
    }
}
