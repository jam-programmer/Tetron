using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.User;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetUsersQueryHandler:IRequestHandler<RequestUsers, PaginatedList<UserViewModel>>
    {
        private readonly IUserFactory _userFactory;

        public GetUsersQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<PaginatedList<UserViewModel>> Handle(RequestUsers request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetPagedSearchWithSizeAsync<UserViewModel>(request.Paginated, cancellationToken);
        }
    }
}
