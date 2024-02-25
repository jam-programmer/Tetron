using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetUserImageQuery:IRequest<UserImage>
    {
        public Guid Id { set; get; }
    }

    public class GetUserImageQueryHandler : IRequestHandler<GetUserImageQuery, UserImage>
    {
        private readonly IUserFactory _userFactory;

        public GetUserImageQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<UserImage> Handle(GetUserImageQuery request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetAvatarAsync(request, cancellationToken);
        }
    }

    public class UserImage
    {
        public string? Avatar { set; get; }
    }
}
