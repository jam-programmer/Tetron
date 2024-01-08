using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Reports.Role;
using Application.Reports.User;
using Application.Reports.UserAddress;
using Application.Services.User;
using Application.Services.UserAddress;
using Domain.Entities;
using Framework.Common.Application.Core;
using Framework.Mapping.User;
using Framework.ViewModels.Role;
using Framework.ViewModels.User;
using Mapster;

namespace Framework.Factories.Identity.User
{
    public class UserFactory : IUserFactory
    {
        private readonly IRoleReport _roleReport;
        private readonly IUserService _userService;
        private readonly IUserReport _userReport;
        private readonly IUserAddressReport _userAddressReport;
        private readonly IUserAddressService _userAddressService;

        public UserFactory(IRoleReport roleReport, IUserService userService, IUserReport userReport, IUserAddressReport userAddressReport, IUserAddressService userAddressService)
        {
            _roleReport = roleReport;
            _userService = userService;
            _userReport = userReport;
            _userAddressReport = userAddressReport;
            _userAddressService = userAddressService;
        }


        public UserFactory(IRoleReport roleReport, IUserService userService, IUserReport userReport)
        {
            _roleReport = roleReport;
            _userService = userService;
            _userReport = userReport;
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


            if (checkAddress && viewModel.Get==false)
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
            if(roleSelected== null) { }

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

            UpdateUserViewModel userViewModel  = user.Adapt<UpdateUserViewModel>();
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
            if (userRole!=null)
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
            if (result.IsSuccess==false)
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
    }
}
