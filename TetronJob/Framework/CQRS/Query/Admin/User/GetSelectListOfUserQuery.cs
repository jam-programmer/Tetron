using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetSelectListOfUserQuery : IRequest<IEnumerable<SelectUser>>
    {

    }


    public class GetSelectListOfUserQueryHandler : IRequestHandler<GetSelectListOfUserQuery, IEnumerable<SelectUser>>
    {
        private readonly IUserFactory _userFactory;

        public GetSelectListOfUserQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<IEnumerable<SelectUser>> Handle(GetSelectListOfUserQuery request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetSelectUserListAsync();
        }
    }

    public class SelectUser
    {
        public Guid Id { set; get; }
        public string? FullName { set; get; }
    }
}
