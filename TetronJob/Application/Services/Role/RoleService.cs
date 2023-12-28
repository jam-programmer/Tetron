using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<RoleEntity> _roleManager;

        public RoleService(RoleManager<RoleEntity> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Response> CreateRoleAsync(RoleEntity role, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //Todo Log
                return Response.Fail();
            }
            var result = await _roleManager.CreateAsync(role);
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

        public async Task<RoleEntity?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }
           
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                //todo
            }

            return role;
        }
    }
}
