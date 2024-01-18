using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.ViewModels.User
{
    public class InsertUserViewModel:IRequest<Response>
    {
        public Guid RoleId { set; get; } = Guid.Parse("d0952898-8ba2-4168-480b-08dc152232a5");
        public IFormFile? AvatarFile { set; get; }
        public string? FullName { set; get; }
        public string? Birthday { set; get; }
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Password { set; get; }
        public string? PhoneNumber { set; get; }
        public bool Active { set; get; } = true;
    }

    public class SetUserAddressViewModel : IRequest<SetUserAddressViewModel>
    {
        public Guid ProvinceId { set; get; }
        public bool Get { set; get; }=true;

        public Guid CityId { set; get; }

        public Guid UserId { set; get; }
    }

    public class UserAddress
    {
        public string? ProvinceId { set; get; }
      

        public string? CityId { set; get; }

        public string? UserId { set; get; }
    }
}
