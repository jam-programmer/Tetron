using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.Role;
using Framework.Factories.Identity.Role;
using Framework.ViewModels.Role;
using MediatR;

namespace Framework.CQRS.Command.Admin.Role
{
    public class InsertRoleCommandHandler : IRequestHandler<InsertRoleViewModel, Response>
    {
        private readonly IRoleFactory _roleFactory;

        public InsertRoleCommandHandler(IRoleFactory roleFactory)
        {
            _roleFactory = roleFactory;
        }
        public async Task<Response> Handle(InsertRoleViewModel request, CancellationToken cancellationToken)
        {
            return await _roleFactory.CreateRoleAsync(request, cancellationToken);
        }
    }
}
