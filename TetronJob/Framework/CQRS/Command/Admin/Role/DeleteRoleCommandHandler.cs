using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.Role;
using Framework.ViewModels.Role;
using MediatR;

namespace Framework.CQRS.Command.Admin.Role
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleViewModel, Response>
    {
        private readonly IRoleFactory _roleFactory;

        public DeleteRoleCommandHandler(IRoleFactory roleFactory)
        {
            _roleFactory = roleFactory;
        }
        public async Task<Response> Handle(DeleteRoleViewModel request, CancellationToken cancellationToken)
        {
            return await _roleFactory.DeleteRoleAsync(request, cancellationToken);
        }
    }
}
