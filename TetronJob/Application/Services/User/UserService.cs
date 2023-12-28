using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.User
{
    public class UserService:IUserService
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserService(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response> CreateUserAsync(UserEntity user, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //Todo Log
                return Response.Fail();
            }

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return Response.Succeded();
            }

            foreach (var error in result.Errors)
            {
                //Todo Log
            }

            return Response.Fail("امکان ثبت نقش کاربری وجود ندارد.");
        }

        public async Task<Response> UpdateUserAsync(UserEntity user, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
                //
            }

            if (user == null)
            {
                //todo}

            }

            Response response = new();
            var result = await _userManager.UpdateAsync(user!);
            if (result.Succeeded)
            {
                response.IsSuccess = true;

            }
            else
            {
                string message = string.Empty;
                foreach (var error in result.Errors)
                {
                    message = error.Description + "\n\r";
                }

                response.Message = message;
            }

            return response;
        }

        public async Task<Response> DeleteUserAsync(UserEntity user, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            { //todo
            }

            if (user == null)
            {
                //todo
            }
            Response response = new();
            var result = await _userManager.DeleteAsync(user!); if (result.Succeeded)
            {
                response.IsSuccess = true;

            }
            else
            {
                string message = string.Empty;
                foreach (var error in result.Errors)
                {
                    message = error.Description + "\n\r";
                }

                response.Message = message;
            }

            return response;
        }

        public async Task<Response> AddNewPasswordAsync(UserEntity user, string password, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {
                //_logger.LogInformation($"-----(UserService) *** The operation was stopped by the user ***");
                return response;
            }
            var resultAddPassword = await _userManager.AddPasswordAsync(user, password);
            if (resultAddPassword.Succeeded)
            {
                response.IsSuccess = true;
                return response;
            }
            foreach (var item in resultAddPassword.Errors)
            {
                response.Message += item.Description + "\r\n";
            }
            //_logger.LogError($"-----(UserService) *** A new password could not be set for the user ==> {response.Message}");
            return response;
        }
        public async Task<Response> AddUserRoleAsync(UserEntity user, string role, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {
                //_logger.LogInformation($"-----(UserService) *** The operation was stopped by the user ***");
                return response;
            }
            var result = await _userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                return response;
            }
            foreach (var item in result.Errors)
            {
                response.Message += item.Description + "\r\n";
            }
            //_logger.LogError($"-----(UserService) *** The new role could not be set for the user ==> {response.Message}");
            return response;
        }
        public async Task<Response> AddUserRolesAsync(UserEntity user, IEnumerable<string> roles, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {
                //_logger.LogInformation($"-----(UserService) *** The operation was stopped by the user ***");
                return response;
            }
            var result = await _userManager.AddToRolesAsync(user, roles);
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                return response;
            }
            foreach (var item in result.Errors)
            {
                response.Message += item.Description + "\r\n";
            }
            //_logger.LogError($"-----(UserService) *** The new role could not be set for the user ==> {response.Message}");
            return response;
        }


        public async Task<Response> RemoveCurrentPasswordAsync(UserEntity user, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {
                //_logger.LogInformation($"-----(UserService) *** The operation was stopped by the user ***");
                return response;
            }
            var resultRemovePassword = await _userManager.RemovePasswordAsync(user);
            if (resultRemovePassword.Succeeded)
            {
                return Response.Succeded();
            }
            foreach (var item in resultRemovePassword.Errors)
            {
                response.Message += item.Description + "\r\n";
            }
            //_logger.LogError($"-----(UserService) *** The current password was not deleted ==> {response.Message}");
            return response;
        }
        public async Task<Response> RemoveRoleAsync(UserEntity user, List<string> roles, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {
                //_logger.LogInformation($"-----(UserService) *** The operation was stopped by the user ***");
                return response;
            }


            var resultRemoveRole = await _userManager.RemoveFromRolesAsync(user, roles);
            if (resultRemoveRole.Succeeded)
            {
                return Response.Succeded();
            }
            foreach (var item in resultRemoveRole.Errors)
            {
                response.Message += item.Description + "\r\n";
            }
            //_logger.LogError($"-----(UserService) *** User roles were not deleted ==> {response.Message}");
            return response;
        }





    }
}
