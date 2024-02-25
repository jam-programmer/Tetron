using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Enums;
using Framework.Factories.Identity.User;
using Framework.Factories.Sender;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class SendOtp:IRequest<Response>
    {
        public string? NationalCode { set; get; }
    }

    public class SendOtpHandler : IRequestHandler<SendOtp, Response>
    {
        private readonly IUserFactory _userFactory;
        private readonly ISenderFactory _senderFactory;

        public SendOtpHandler(IUserFactory userFactory, ISenderFactory senderFactory)
        {
            _userFactory = userFactory;
            _senderFactory = senderFactory;
        }
        public async Task<Response> Handle(SendOtp request, CancellationToken cancellationToken)
        {
            var result= await _userFactory.SendOtpAsync(request, cancellationToken);

            if (result.IsSuccess == true)
            {
                Dictionary<string, string>? data = (Dictionary<string, string>)result.Data!;
                var phoneNumber = data["phoneNumber"];
                var code = data["otpCode"];
                await _senderFactory.Send(phoneNumber, code);
            }

            return result;
        }
    }
}
