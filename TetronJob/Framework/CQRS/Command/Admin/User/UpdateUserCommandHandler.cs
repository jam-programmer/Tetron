using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserViewModel, Response>
    {
        public Task<Response> Handle(UpdateUserViewModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
