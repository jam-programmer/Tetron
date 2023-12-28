using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ViewModels.Role;

namespace Framework.Factories.Identity.Role
{
    public interface IRoleFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);


        Task<Response> CreateRoleAsync(InsertRoleViewModel model, CancellationToken cancellation);
        Task<UpdateRoleViewModel?> GetRoleByIdAsync(Guid id,CancellationToken cancellation);
        Task<Response> UpdateRoleAsync(UpdateRoleViewModel model, CancellationToken cancellation);
        Task<Response> DeleteRoleAsync(DeleteRoleViewModel model, CancellationToken cancellation);
    }
}
