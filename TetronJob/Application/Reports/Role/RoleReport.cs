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
    }
}
