using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetUserAdvertisesQuery:IRequest<List<UserAdvertises>>
    {
        public Guid Id { set; get; }
    }

    public class GetUserAdvertisesQueryHandler : IRequestHandler<GetUserAdvertisesQuery, List<UserAdvertises>>
    {
        private readonly IUserFactory _userFactory;

        public GetUserAdvertisesQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<List<UserAdvertises>?> Handle(GetUserAdvertisesQuery request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetUserAdvertisesAsync(request.Id);
        }
    }

    public class UserAdvertises
    {
        public Guid Id { set; get; }
        public string? Type { set; get; }
        public string? Title { set; get; }
        public string? Image { set; get; }
    }
}
