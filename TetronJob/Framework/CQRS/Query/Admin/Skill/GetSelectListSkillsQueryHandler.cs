using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Skill;
using Framework.ViewModels.Skill;
using MediatR;

namespace Framework.CQRS.Query.Admin.Skill
{
    public class GetSelectListSkillsQueryHandler:IRequestHandler<RequestGetSkills,List<SkillViewModel>>
    {
        private readonly ISkillFactory _skillFactory;

        public GetSelectListSkillsQueryHandler(ISkillFactory skillFactory)
        {
            _skillFactory = skillFactory;
        }
        public async Task<List<SkillViewModel>> Handle(RequestGetSkills request, CancellationToken cancellationToken)
        {
            return await _skillFactory.GetSkillsAsync();
        }
    }
}
