using Application.Models;
using Domain.Entities;

namespace Application.Services.User
{
    public interface IUserService
    {

        Task<Response> AddUserRolesAsync(UserEntity user, IEnumerable<string> roles, 
            CancellationToken cancellation);
        Task<Response> RemoveCurrentPasswordAsync(UserEntity user, CancellationToken cancellation);
        Task<Response> AddNewPasswordAsync(UserEntity user, string password, CancellationToken cancellation);
        Task<Response> RemoveRolesAsync(UserEntity user, List<string> roles, CancellationToken cancellation);
        Task<Response> RemoveRoleAsync(UserEntity user, string role, CancellationToken cancellation);
        Task<Response> AddUserRoleAsync(UserEntity user, string role, CancellationToken cancellation);


        Task<Response> CreateUserAsync(UserEntity user, CancellationToken cancellation);
        Task<Response> UpdateUserAsync(UserEntity user, CancellationToken cancellation);
        Task<Response> DeleteUserAsync(UserEntity user, CancellationToken cancellation);
    }
}
