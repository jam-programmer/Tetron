using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Skill;
using Framework.ViewModels.Skill;
using MediatR;

namespace Framework.CQRS.Query.Admin.Skill
{
    public class GetSkillsQueryHandler:IRequestHandler<RequestSkills,PaginatedList<SkillViewModel>>
    {
        private readonly ISkillFactory _skillFactory;

        public GetSkillsQueryHandler(ISkillFactory skillFactory)
        {
            _skillFactory = skillFactory;
        }
        public async Task<PaginatedList<SkillViewModel>> Handle(RequestSkills request, CancellationToken cancellationToken)
        {
            return await _skillFactory.GetPagedSearchWithSizeAsync<SkillViewModel>(request.Paginated!,
                cancellationToken);
        }
    }
}
