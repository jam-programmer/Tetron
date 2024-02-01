using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.Skill;
using Application.Reports.SkillIntroduction;
using Application.Services.Skill;
using Domain.Entities;
using Framework.ViewModels.Skill;
using Mapster;

namespace Framework.Factories.Skill
{
    public class SkillFactory: ISkillFactory
    {
        private readonly ISkillService _service;
        private readonly ISkillReport _report;

        public SkillFactory(ISkillService service, ISkillReport report)
        {
            _service = service;
            _report = report;
        }
        public async Task<List<SkillViewModel>> GetSkillsAsync()
        {
            var list = await _report.GetSkills();
            List<SkillViewModel> skills = list.Adapt<List<SkillViewModel>>();
            return skills;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertSkillAsync(InsertSkillViewModel viewModel, CancellationToken cancellation)
        {
            SkillEntity skill = viewModel.Adapt<SkillEntity>();
            var result = await _service.InsertAsync(skill,cancellation);
            return result;
        }

        public async Task<Response> UpdateSkillAsync(UpdateSkillViewModel viewModel, CancellationToken cancellation)
        {
            var skill = await _report.GetByIdAsync(viewModel.Id, cancellation);
            skill.SkillName=viewModel.SkillName;
            var result=await _service.UpdateAsync(skill,cancellation);
            return result;
        }

        public async Task<Response> DeleteSkillAsync(DeleteSkillViewModel viewModel, CancellationToken cancellation)
        {
            var skill = await _report.GetByIdAsync(viewModel.Id, cancellation);
            var result=await _service.DeleteAsync(skill,cancellation);
            return result;
        }

        public async Task<UpdateSkillViewModel> GetSkillByIdAsync(RequestGetSkillById request, CancellationToken cancellation)
        {
            var skill = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateSkillViewModel skillViewModel = skill.Adapt<UpdateSkillViewModel>();
            return  skillViewModel;
        }
    }
}
