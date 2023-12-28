using Application.Models;
using Domain.Entities;

namespace Application.Reports.User
{
    public interface IUserReport
    {
        Task<UserEntity?> GetUserByIdAsync(Guid userId, CancellationToken cancellation);
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
    }
}
