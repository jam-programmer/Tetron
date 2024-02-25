using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Identity.User;
using MediatR;

namespace Framework.CQRS.Command.Admin.User
{
    public class EditProfileCommandHandler:IRequestHandler<EditProfile,Response>
    {
        private readonly IUserFactory _userFactory;

        public EditProfileCommandHandler(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }
        public async Task<Response> Handle(EditProfile request, CancellationToken cancellationToken)
        {
            return await _userFactory.EditProfileAsync(request, cancellationToken);
        }
    }

    public class EditProfile:IRequest<Response>
    {
        public string? PhoneNumber { set; get; }
        public string? Email { set; get; }
        public string? Password { set; get; }
        public string? FullName { set; get; }
        public IFormFile? AvatarFile { set; get; }
        public string? Avatar { set; get; }
        public Guid Id { set; get; }
    }
}
