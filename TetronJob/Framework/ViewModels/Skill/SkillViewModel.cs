using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.ViewModels.Province;
using MediatR;

namespace Framework.ViewModels.Skill
{
    public class SkillViewModel
    {
        public Guid Id { get; set; }
        public string? SkillName { set; get; }
    }

    public class RequestSkills:IRequest<PaginatedList<SkillViewModel>>
    {
        public PaginatedWithSize? Paginated { set; get; }
    }
    public class DeleteSkillViewModel : IRequest<Response>
    {
        public Guid Id { get; set; }

    }

    public class RequestGetSkills : IRequest<List<SkillViewModel>>
    {

    }

   

}
