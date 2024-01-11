using Framework.Factories.Category;
using Framework.ViewModels.Category;
using MediatR;

namespace Framework.CQRS.Query.Admin.Category
{
    public class GetSelectListCategoriesQueryHandler : IRequestHandler<RequestGetCategories, IEnumerable<CategoryViewModel>>
    {
        private readonly ICategoryFactory _categoryFactory;

        public GetSelectListCategoriesQueryHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public async Task<IEnumerable<CategoryViewModel>> Handle(RequestGetCategories request, CancellationToken cancellationToken)
        {
            return await _categoryFactory.GetCategoriesAsync();
        }
    }
}
