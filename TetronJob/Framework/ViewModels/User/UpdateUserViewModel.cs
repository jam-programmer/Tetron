using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.User
{
    public class UpdateUserViewModel:IRequest<Response>
    {
        public Guid Id { set; get; }
        public Guid? RoleId { set; get; }
        public string? FullName { set; get; }
        public IFormFile? AvatarFile { set; get; }
        public string? AvatarPath { set; get; }
        public string? Birthday { set; get; }
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Password { set; get; }
        public string? PhoneNumber { set; get; }
        public bool Active { set; get; } = false;
    }

    public class RequestGetUserById:IRequest<UpdateUserViewModel>
    {
        public Guid Id { set; get; }
    }
}
