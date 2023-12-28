using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Role
{
    public class RoleViewModel
    {
        public Guid Id { set; get; }
        public string? Name { set; get; }
        public string? PersianName { set; get; }

    }

    public class RequestRoles : IRequest<PaginatedList<RoleViewModel>>
    {
        public PaginatedWithSize? Paginated { set; get; }
    }

    public class DeleteRoleViewModel : IRequest<Response>
    {
        public Guid Id { set; get; }
    }
}
