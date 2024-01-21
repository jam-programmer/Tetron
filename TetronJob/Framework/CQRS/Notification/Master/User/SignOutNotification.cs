using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Notification.Master.User
{
    public class SignOutNotification:INotificationHandler<SignOut>
    {
        private readonly IUserFactory _userFactory;

        public SignOutNotification(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task Handle(SignOut notification, CancellationToken cancellationToken)
        {
             await _userFactory.SignOutAsync();
        }
    }

    public class SignOut:INotification
    {

    }
}
