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
    public class SetUserAddressCommandHandler : IRequestHandler<SetUserAddressViewModel, SetUserAddressViewModel>
    {
        private readonly IUserFactory _userFactory;

        public SetUserAddressCommandHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<SetUserAddressViewModel> Handle(SetUserAddressViewModel request, CancellationToken cancellationToken)
        {
            return await _userFactory.SetUserAddressAsync(request, cancellationToken);
        }
    }
}
