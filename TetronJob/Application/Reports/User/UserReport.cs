using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.User
{
    public class UserReport:IUserReport
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserReport(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public Task<UserEntity?> GetUserByIdAsync(Guid userId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = _userManager.Users.AsNoTracking().AsQueryable();

            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.PhoneNumber!.Contains(pagination.Keyword) || r.UserName!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<UserEntity, TDestination>(pagination.Page, 
                pagination.PageSize,
                config: null, cancellationToken);
        }
    }
}
