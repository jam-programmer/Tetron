using Application.Models;
using Framework.CQRS.Command.Admin.User;
using Framework.CQRS.Query.Admin.User;
using Framework.ViewModels.User;

namespace Framework.Factories.Identity.User
{
    public interface IUserFactory
    {

        #region AdminPanel


        Task<UserCategoryViewModel> SetCategories(UserCategoryViewModel model, CancellationToken cancellation = default);
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<SetUserAddressViewModel> SetUserAddressAsync(SetUserAddressViewModel viewModel, CancellationToken cancellation);
        Task<Response> InsertUserAsync(InsertUserViewModel model, CancellationToken cancellationToken = default);
        Task<Response> UpdateUserAsync(UpdateUserViewModel model, CancellationToken cancellationToken = default);
        Task<UpdateUserViewModel> GetUserByIdAsync(RequestGetUserById request, CancellationToken cancellationToken = default);
        Task<Response> DeleteUserAsync(DeleteUserViewModel model, CancellationToken cancellationToken = default);


        Task<IEnumerable<SelectUser>> GetSelectUserListAsync();

        #endregion

        Task<UserCategory> GetUserCategoryByIdAsync(Guid id);
        Task<List<UserAdvertises>?> GetUserAdvertisesAsync(Guid id);
        Task<Response> SignInAsync(SignInCommand command);
        Task SignOutAsync();
    }
}
