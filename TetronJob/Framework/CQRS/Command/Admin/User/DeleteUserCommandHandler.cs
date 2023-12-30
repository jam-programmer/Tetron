using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.User;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserViewModel,Response>
    {
        private readonly IUserFactory _userFactory;

        public DeleteUserCommandHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<Response> Handle(DeleteUserViewModel request, CancellationToken cancellationToken)
        {
            return await _userFactory.DeleteUserAsync(request, cancellationToken);
        }
    }
}
