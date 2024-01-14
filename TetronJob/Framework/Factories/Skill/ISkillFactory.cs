using Application.Models;
using Framework.ViewModels.Skill;


namespace Framework.Factories.Skill
{
    public interface ISkillFactory
    {
        Task<List<SkillViewModel>> GetSkillsAsync();
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> InsertSkillAsync(InsertSkillViewModel viewModel, CancellationToken cancellation);
        Task<Response> UpdateSkillAsync(UpdateSkillViewModel viewModel, CancellationToken cancellation);
        Task<Response> DeleteSkillAsync(DeleteSkillViewModel viewModel, CancellationToken cancellation);
        Task<UpdateSkillViewModel> GetSkillByIdAsync(RequestGetSkillById request, CancellationToken cancellation);

    }
}
