using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.Role;
using Framework.ViewModels.Role;
using MediatR;

namespace Framework.CQRS.Query.Admin.Role
{
    public class RoleQueryHandler : IRequestHandler<RequestRoles, PaginatedList<RoleViewModel>>
    {
        private readonly IRoleFactory _roleFactory;

        public RoleQueryHandler(IRoleFactory roleFactory)
        {
            _roleFactory = roleFactory;
        }
        public async Task<PaginatedList<RoleViewModel>> Handle(RequestRoles request, CancellationToken cancellationToken)
        {
            return await _roleFactory.GetPagedSearchWithSizeAsync<RoleViewModel>(request.Paginated!, cancellationToken);
        }
    }
}
