using Framework.Factories.Identity.User;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<RequestGetUserById, UpdateUserViewModel>
    {
        private readonly IUserFactory _userFactory;

        public GetUserByIdQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<UpdateUserViewModel>
            Handle(RequestGetUserById request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetUserByIdAsync(request, cancellationToken);
        }
    }
}
