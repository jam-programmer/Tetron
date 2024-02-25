using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class SignInOtp:IRequest<Response>
    {
        public string NationalCode { set; get; }
        public string OtpCode { set; get; }
    }

    public class SignInOtpHandler : IRequestHandler<SignInOtp, Response>
    {
        private readonly IUserFactory _userFactory;

        public SignInOtpHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<Response> Handle(SignInOtp request, CancellationToken cancellationToken)
        {
            return await _userFactory.SignInOtpAsync(request, cancellationToken);
        }
    }
}
