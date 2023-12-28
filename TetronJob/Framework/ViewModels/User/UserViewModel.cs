using Application.Models;
using Framework.ViewModels.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ViewModels.User
{
    public class UserViewModel
    {
        public  string? PhoneNumber { get; set; }
        public  string? UserName { get; set; }
        public string? Avatar { set; get; }
        public Guid Id { set; get; }
    }
    public class RequestUsers : IRequest<PaginatedList<UserViewModel>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }

}
