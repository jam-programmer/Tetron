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
    public class GetRolesForSelectQuery : IRequestHandler<RequestSelectedRoles, IEnumerable<RoleViewModel>>
    {
        private readonly IRoleFactory _roleFactory;

        public GetRolesForSelectQuery(IRoleFactory roleFactory)
        {
            _roleFactory = roleFactory;
        }
        public async Task<IEnumerable<RoleViewModel>> Handle(RequestSelectedRoles request, CancellationToken cancellationToken)
        {
            return await _roleFactory.GetRolesAsync(cancellationToken);
        }
    }
}
