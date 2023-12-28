using Application.Models;
using Application.Reports.Role;
using Application.Services.Role;
using Domain.Entities;
using Framework.ViewModels.Role;
using Mapster;

namespace Framework.Factories.Identity.Role
{
    public class RoleFactory : IRoleFactory
    {
        private readonly IRoleReport _roleReport;
        private readonly IRoleService _roleService;

        public RoleFactory(IRoleReport roleReport, IRoleService roleService)
        {
            _roleReport = roleReport;
            _roleService = roleService;
        }

        public async Task<Response> CreateRoleAsync(InsertRoleViewModel model, CancellationToken cancellation)
        {
            Response response = new();
            RoleEntity role = new();
            role = model.Adapt<RoleEntity>();
            response = await _roleService.CreateRoleAsync(role, cancellation);
            return response;
        }

        public async Task<UpdateRoleViewModel?> GetRoleByIdAsync(Guid id, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //Todo Log
            }

            var role = await _roleReport.GetRoleByIdAsync(id, cancellation);
            UpdateRoleViewModel roleViewModel = role.Adapt<UpdateRoleViewModel>();
            return roleViewModel;
        }

        public async Task<Response> UpdateRoleAsync(UpdateRoleViewModel model, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            if (model == null)
            {

            }

            var role = await _roleReport.GetRoleByIdAsync(model!.Id, cancellation);
            if(role == null) { }

            role!.PersianName=model.PersianName;
            role.Name = model.Name;
            var response = await _roleService.UpdateRoleAsync(role, cancellation);
            return response;
        }

        public async Task<Response> DeleteRoleAsync(DeleteRoleViewModel model, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            if (model == null)
            {
                //todo
            }

            var role = await _roleReport.GetRoleByIdAsync(model!.Id, cancellation);
            if (role == null)
            {
                //todo
            }

            var response = await _roleService.DeleteRoleAsync(role!, cancellation);
            return response;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
            (PaginatedWithSize pagination, CancellationToken cancellationToken = default)
        {
            return await _roleReport.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }
    }
}
