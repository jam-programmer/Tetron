using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Reports.Role;
using Application.Reports.User;
using Application.Services.User;
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

            List<string> roles = new List<string>();
            roles.Add(model.RoleId.ToString()!);
            var resultRemoveRole = await _userService.RemoveRoleAsync(user!, roles, cancellationToken);
            if (resultRemoveRole.IsSuccess == false)
            {
                //todo
            }
            var resultSetNewRole=
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

        
    }
}
