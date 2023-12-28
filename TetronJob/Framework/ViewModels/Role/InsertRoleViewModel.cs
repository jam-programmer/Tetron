using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Role
{
    public class InsertRoleViewModel:IRequest<Response>
    {
        public string? PersianName { set; get; }
        public string? Name { set; get; }
    }
}
