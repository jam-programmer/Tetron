using Application.Models;
using Application.Reports.CategoryUser;
using Application.Reports.Role;
using Application.Reports.User;
using Application.Reports.UserAddress;
using Application.Services.CategoryUser;
using Application.Services.User;
using Application.Services.UserAddress;
using Domain.Entities;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Admin.User;
using Framework.CQRS.Query.Admin.User;
using Framework.Mapping.User;
using Framework.ViewModels.User;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Framework.Factories.Identity.User
{
    public class UserFactory : IUserFactory
    {
        private readonly IRoleReport _roleReport;
        private readonly IUserService _userService;
        private readonly IUserReport _userReport;
        private readonly IUserAddressReport _userAddressReport;
        private readonly IUserAddressService _userAddressService;
        private readonly ICategoryUserReport _categoryUserReport;
        private readonly ICategoryUserService _categoryUserService;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserFactory(IRoleReport roleReport, IUserService userService, IUserReport userReport, IUserAddressReport userAddressReport, IUserAddressService userAddressService, ICategoryUserReport categoryUserReport, ICategoryUserService categoryUserService, SignInManager<UserEntity> signInManager)
        {
            _roleReport = roleReport;
            _userService = userService;
            _userReport = userReport;
            _userAddressReport = userAddressReport;
            _userAddressService = userAddressService;
            _categoryUserReport = categoryUserReport;
            _categoryUserService = categoryUserService;
            _signInManager = signInManager;
        }

        #region AdminPaenl


        public async Task<UserCategoryViewModel> SetCategories(UserCategoryViewModel model, CancellationToken cancellation = default)
        {
            UserCategoryViewModel viewModel = new();
            var check = await _categoryUserReport.CheckExistCategoryAsync(model.UserId, cancellation);
            if (check)
            {
                var categories = await _categoryUserReport.GetCategoriesByUserIdAsync(model.UserId, cancellation);
                if (model.Get == false)
                {

                    var delete = await _categoryUserService.DeleteAsync(categories, cancellation);
                    if (delete.IsSuccess == false)
                    {
                        //todo
                    }

                    List<CategoryUserEntity> newCategories = new();
                    foreach (var id in model.CategoryIds!)
                    {
                        newCategories.Add(new CategoryUserEntity()
                        {
                            CategoryId = id,
                            UserId = model.UserId
                        });
                    }

                    var insert = await _categoryUserService.InsertAsync(newCategories, cancellation);
                    if (insert.IsSuccess == false)
                    {
                        //todo
                    }
                }
                else
                {
                    foreach (var item in categories)
                    {
                        viewModel.CategoryIds!.Add(item.CategoryId);
                    }
                }

            }
            else
            {
                List<CategoryUserEntity> newCategories = new();
                foreach (var id in model.CategoryIds!)
                {
                    newCategories.Add(new CategoryUserEntity()
                    {
                        CategoryId = id,
                        UserId = model.UserId
                    });
                }

                var insert = await _categoryUserService.InsertAsync(newCategories, cancellation);
                if (insert.IsSuccess == false)
                {
                    //todo
                }
            }

            return viewModel;
        }

        public async Task<PaginatedList<TViewModel>>
            GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _userReport.GetAllPaginatedAsync<TViewModel>
                (pagination, cancellationToken);

        }

        public async Task<SetUserAddressViewModel> SetUserAddressAsync(SetUserAddressViewModel viewModel,
            CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //
            }


            var checkAddress = await _userAddressReport.ExistUserAddressAsync(viewModel.UserId);

            if (checkAddress == true && viewModel.Get)
            {
                var address = await _userAddressReport.
                    GetUserAddressByIdAsync(viewModel.UserId);
                viewModel = address.Adapt<SetUserAddressViewModel>();
                return viewModel;
            }

            if (checkAddress == false && viewModel.Get)
            {

                return new SetUserAddressViewModel()
                {
                    UserId = viewModel.UserId
                };
            }


            if (checkAddress && viewModel.Get == false)
            {
                var getAddress = await _userAddressReport.GetUserAddressByIdAsync(viewModel.UserId);
                getAddress!.CityId = viewModel.CityId;
                getAddress.ProvinceId = viewModel.ProvinceId;
                await _userAddressService.UpdateAsync(getAddress);

            }
            else
            {
                UserAddressEntity address = new();
                address = viewModel.Adapt<UserAddressEntity>();
                await _userAddressService.InsertAsync(address);
            }

            return viewModel;

        }

        public async Task<Response> UpdateUserAsync(UpdateUserViewModel model,
            CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                //todo
            }

            var user = await _userReport.GetUserByIdAsync(model.Id, cancellationToken);
            if (user == null)
            {
                //todo
            }
            model.Adapt(user, UserMap.ConfigUpdate());

            user!.EmailConfirmed = model.Active;
            user.PhoneNumberConfirmed = model.Active;

            if (!string.IsNullOrEmpty(model.Password))
            {
                var resultRemovePassword = await _userService
                    .RemoveCurrentPasswordAsync(user!, cancellationToken);
                if (resultRemovePassword.IsSuccess == false)
                {
                    //todo 
                }

                var resultSetNewPassword = await _userService.AddNewPasswordAsync(user!, model.Password!, cancellationToken);
                if (resultSetNewPassword.IsSuccess == false)
                {
                    //todo
                }
            }

            var userRole = await _userReport.GetUserRoleByUserIdAsync(user, cancellationToken);
            if (userRole == null || string.IsNullOrEmpty(userRole))
            {

            }

            var resultRemoveRole = await _userService.RemoveRoleAsync(user!, userRole!, cancellationToken);
            if (resultRemoveRole.IsSuccess == false)
            {
                //todo
            }

            var roleSelected = await _roleReport.GetRoleByIdAsync(model.RoleId, cancellationToken);
            if (roleSelected == null) { }

            var resultSetNewRole = await _userService.AddUserRoleAsync(user!, roleSelected!.Name!, cancellationToken);
            if (resultSetNewRole.IsSuccess == false)
            {
                //todo
            }

            if (model.AvatarFile != null)
            {
                user.Avatar = FileProcessing.FileUpload(model.AvatarFile, model.AvatarPath, "UsersImage");
            }


            var resultUpdate = await _userService.UpdateUserAsync(user!, cancellationToken);
            return resultUpdate;

        }

        public async Task<UpdateUserViewModel> GetUserByIdAsync
            (RequestGetUserById request, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                //todo
            }

            if (request == null)
            {
                //todo
            }

            var user = await _userReport.GetUserByIdAsync(request!.Id, cancellationToken);
            if (user == null)
            {
                //todo
            }

            UpdateUserViewModel userViewModel = user.Adapt<UpdateUserViewModel>();
            userViewModel.AvatarPath = user!.Avatar;
            if (user!.EmailConfirmed == true && user.PhoneNumberConfirmed == true)
            {
                userViewModel.Active = true;
            }

            var role = await _userReport.GetUserRoleByUserIdAsync(user, cancellationToken);
            if (string.IsNullOrEmpty(role))
            {
                //todo
            }

            var userRole = await _roleReport.GetRoleByNameAsync(role!, cancellationToken);
            if (userRole != null)
            {
                userViewModel.RoleId = userRole.Id;
            }


            return userViewModel;
        }

        public async Task<Response> InsertUserAsync(InsertUserViewModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                //todo
            }

            if (model == null)
            {
                //todo
            }

            UserEntity user = new();
            user = model.Adapt<UserEntity>();
            if (model!.Active)
            {

                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
            }
            user.Avatar = FileProcessing.FileUpload(model!.AvatarFile, null, "UsersImage");
            var result = await _userService.CreateUserAsync(user, cancellationToken);
            if (result.IsSuccess == false)
            {
                return result;
            }
            var resultPassword = await _userService.AddNewPasswordAsync(user, model!.Password!, cancellationToken);
            if (resultPassword.IsSuccess == false)
            {
                return resultPassword;
            }

            var role = await _roleReport.GetRoleByIdAsync(model.RoleId, cancellationToken);
            if (role == null)
            {
                //todo
            }

            var resultRole = await _userService.AddUserRoleAsync(user, role!.Name!, cancellationToken);
            if (resultRole.IsSuccess == false)
            {
                return resultRole;
            }

            Response response = new();
            response.Data = user.Id.ToString();
            response.IsSuccess = true;
            return response;
        }

        public async Task<Response> DeleteUserAsync(DeleteUserViewModel model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            if (model == null)
            {
                //todo
            }

            var user = await _userReport.GetUserByIdAsync(model!.Id, cancellationToken);
            if (user == null)
            {

            }

            var removePassword = await _userService.RemoveCurrentPasswordAsync(user!, cancellationToken);
            if (removePassword.IsSuccess == false)
            {

            }
            var userRole = await _userReport.GetUserRoleByUserIdAsync(user!, cancellationToken);
            if (string.IsNullOrEmpty(userRole))
            {

            }

            var removeRole = await _userService.RemoveRoleAsync(user!, userRole!, cancellationToken);
            if (removeRole.IsSuccess == false)
            {

            }
            FileProcessing.RemoveFile(user!.Avatar!, "UsersImage");
            var removeUser = await _userService.DeleteUserAsync(user!, cancellationToken);
            return removeUser;
        }

        public async Task<IEnumerable<SelectUser>> GetSelectUserListAsync()
        {
            var model = await _userReport.GetUserForSelectAsync();
            IEnumerable<SelectUser> user = model.Adapt<IEnumerable<SelectUser>>();
            return user;
        }

        public async Task<UserCategory> GetUserCategoryByIdAsync(Guid id)
        {
            var model = await _userReport.GetUserByIdWithOtherInfoAsync(id);
            UserCategory user = new();
            user.CityName = model.Address.City.Name;
            user.ProvinceName = model.Address.Province.Name;
            user.FullName = model.FullName;
            user.Id = model.Id;
            return user;
        }

        public async Task<List<UserAdvertises>?> GetUserAdvertisesAsync(Guid id)
        {
            return await _userReport.GetUserAdvertising<UserAdvertises>(id);
        }

        #endregion


        public async Task<Response> SignInAsync(SignInCommand command)
        {
            Response response = new();
            var existUser = await _userReport.ExistUserAsync(command.UserName);
            if (existUser.IsSuccess == false)
            {
                return Response.Fail("حساب کاربری یا رمز عبور اشتباه است.");
            }

            var activeUser = await _userReport.ActiveUserAsync(command.UserName);
            if (activeUser.IsSuccess == false)
            {
                return Response.Fail("حساب کاربری غیرفعال است.");
            }

            var user = await _userReport.GetUserByUserName(command.UserName);
            if (user == null)
            {
                return Response.Fail("حساب کاربری شما در دسترس نمی باشد با پشتیبان ارتباط برقرار کنید.");
            }

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, command.Password, true);
            if (!checkPassword.Succeeded)
            {
                return Response.Fail("حساب کاربری یا رمز عبور اشتباه است.");
            }

            await _signInManager.SignInAsync(user, isPersistent: command.Remember);
             response.IsSuccess = true;
            return response;

        }

        public async Task SignOutAsync()
        { 
            await _signInManager.SignOutAsync();
           
        }
    }
}
