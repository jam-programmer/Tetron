using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetUserCategoryByIdQuery:IRequest<UserCategory>
    {
        public Guid Id { get; set; }
    }

    public class GetUserCategoryByIdQueryHandler : IRequestHandler<GetUserCategoryByIdQuery, UserCategory>
    {
        private readonly IUserFactory _userFactory;

        public GetUserCategoryByIdQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<UserCategory> Handle(GetUserCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetUserCategoryByIdAsync(request.Id);
        }
    }
    public class UserCategory
    {
        public Guid Id { get; set; }

        public string? Avatar { set; get; }
        public string? FullName { set; get; }
        public string? ProvinceName { set; get; }
        public string? CityName { set; get; }
    }
}
