using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Sender;
using MediatR;

namespace Framework.CQRS.Notification.Master.User
{
    public class WelcomeNotification : INotification
    {
        public string? Name { set; get; }
        public string? PhoneNumber { set; get; }
    }

    public class WelcomeNotificationHandler : INotificationHandler<WelcomeNotification>
    {
        private readonly ISenderFactory _senderFactory;

        public WelcomeNotificationHandler(ISenderFactory senderFactory)
        {
            _senderFactory = senderFactory;
        }
        public async Task Handle(WelcomeNotification notification, CancellationToken cancellationToken)
        {
            await _senderFactory.Welcome(notification.Name!, notification.PhoneNumber!);
        }
    }



}
