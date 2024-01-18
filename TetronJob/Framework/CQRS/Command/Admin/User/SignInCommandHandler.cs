using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class SignInCommandHandler:IRequestHandler<SignInCommand,Response>
    {
        private readonly IUserFactory _userFactory;

        public SignInCommandHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<Response> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            return await _userFactory.SignInAsync(request);
        }
    }

    public class SignInCommand:IRequest<Response>
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Remember { set; get; } = true;
    }

    public class SignInCommandValidation:BaseValidator<SignInCommand>
    {
        public SignInCommandValidation()
        {
            RuleFor(f => f.Password).NotNull().NotEmpty().WithMessage("رمز عبور را وارد کنید");
            RuleFor(f => f.UserName).NotNull().NotEmpty().WithMessage("کدملی یا ایمیل را وارد کنید");
        }
    }
}
