using Framework.Factories.Identity.User;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    internal class SetUserCategoryCommandHandler : IRequestHandler<UserCategoryViewModel, UserCategoryViewModel>
    {
        private readonly IUserFactory _userFactory;

        public SetUserCategoryCommandHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<UserCategoryViewModel> Handle(UserCategoryViewModel request, CancellationToken cancellationToken)
        {
            return await _userFactory.SetCategories(request, cancellationToken);
        }
    }
}
