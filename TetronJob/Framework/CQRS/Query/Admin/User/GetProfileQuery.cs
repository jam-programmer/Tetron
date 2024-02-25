using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Admin.User;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Query.Admin.User
{
    public class GetProfileQuery:IRequest<EditProfile>
    {
        public Guid Id { get; set; }
    }

    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, EditProfile>
    {
        private readonly IUserFactory _userFactory;

        public GetProfileQueryHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<EditProfile> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            return await _userFactory.GetProfileByIdAsync(request, cancellationToken);
        }
    }
}
