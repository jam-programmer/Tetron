using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Notification.Master.User;
using Framework.Factories.Identity.User;
using Framework.ViewModels.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class InsertUserCommandHandler:IRequestHandler<InsertUserViewModel,Response>
    {
        private readonly IUserFactory _userFactory;
        private readonly IMediator _mediator;

        public InsertUserCommandHandler(IUserFactory userFactory, IMediator mediator)
        {
            _userFactory = userFactory;
            _mediator = mediator;
        }
        public async Task<Response> Handle(InsertUserViewModel request, CancellationToken cancellationToken)
        {

            var result= await _userFactory.InsertUserAsync(request, cancellationToken);
            if (result.IsSuccess == true)
            {
                await _mediator.Publish(new WelcomeNotification()
                {
                    Name = request.FullName,
                    PhoneNumber = request.PhoneNumber
                },cancellationToken);
            }
            return result;
        }
    }
}
