using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Identity.Role;
using Framework.ViewModels.Role;
using MediatR;

namespace Framework.CQRS.Query.Admin.Role
{
    public class GetRoleByIdQueryHandler:IRequestHandler<RequestGetRoleById, UpdateRoleViewModel>
    {
        private readonly IRoleFactory _roleFactory;

        public GetRoleByIdQueryHandler(IRoleFactory roleFactory)
        {
            _roleFactory = roleFactory;
        }
        public async Task<UpdateRoleViewModel?> Handle(RequestGetRoleById request, CancellationToken cancellationToken)
        {
            return await _roleFactory.GetRoleByIdAsync(request.RoleId, cancellationToken);
        }
    }
}
