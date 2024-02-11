using Application.Models;
using Domain.Entities;

namespace Application.Reports.User
{
    public interface IUserReport
    {
        Task<UserEntity?> GetUserByIdAsync(Guid userId, CancellationToken cancellation=default);
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<string?> GetUserRoleByUserIdAsync(UserEntity? user, CancellationToken cancellation);

        Task<Response> ExistUserAsync(string national);
        Task<Response> ActiveUserAsync(string nationalCodeOrMail);
        Task<UserEntity?> GetUserByUserName(string national, CancellationToken cancellationToken = default);

        Task<UserEntity?> GetUserByIdWithOtherInfoAsync(Guid userId);
        Task<IEnumerable<UserEntity>> GetUserForSelectAsync();
        Task<List<TModel>?> GetUserAdvertising<TModel>(Guid userId);
    }
}
