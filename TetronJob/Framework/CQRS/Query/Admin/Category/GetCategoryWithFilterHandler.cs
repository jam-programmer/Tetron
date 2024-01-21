using Framework.Factories.Category;
using MediatR;

namespace Framework.CQRS.Query.Admin.Category
{
    public class GetCategoryWithFilterHandler:IRequestHandler<CategoryFilter, UserCategoryResult>
    { 
        private readonly ICategoryFactory _categoryFactory;

        public GetCategoryWithFilterHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public async Task<UserCategoryResult> Handle(CategoryFilter request, CancellationToken cancellationToken)
        {
            return await _categoryFactory.GetUsersCategory(request);
        }
    }

    public class UserCategoryResult
    {
        public CategoryFilter Filter { set; get; }
        public List<UsersCategory> Users { get; set; }
    }

    public class CategoryFilter:IRequest<UserCategoryResult>
    {
        public Guid? CategoryId { get; set; }
        public Guid? ProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public string? @Search { get; set; }

    }

    public class UsersCategory
    {
        public Guid Id { get; set; }
        public string ProvinceName { set; get; }
        public string CityName { set; get; }
        public string FullName { set; get; }
    }

}
