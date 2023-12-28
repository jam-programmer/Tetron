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
            user.Avatar = FileProcessing.FileUpload(model!.AvatarFile, null, "UsersImage");
            var result = await _userService.CreateUserAsync(user, cancellationToken);
            if (result.IsSuccess)
            {
                return result;
            }
            var resultPassword = await _userService.AddNewPasswordAsync(user, model!.Password!, cancellationToken);
            if (resultPassword.IsSuccess)
            {
                return resultPassword;
            }

            var role = await _roleReport.GetRoleByIdAsync(model.RoleId, cancellationToken);
            if (role == null)
            {
                //todo
            }

            var resultRole = await _userService.AddUserRoleAsync(user, role!.Name!, cancellationToken);
            if (resultRole.IsSuccess)
            {
                return resultRole;
            }

            Response response = new();
            response.IsSuccess = true;
            return response;
        }

        
    }
}
