using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Skill
{
    public class UpdateSkillViewModel:IRequest<Response>
    {
        public string? SkillName { set; get; }
        public Guid Id { set; get; }
    }

    public class RequestGetSkillById : IRequest<UpdateSkillViewModel>
    {
        public Guid Id { set; get; }
    }
}
