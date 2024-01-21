using Domain.Entities;

namespace Application.Reports.CategoryUser
{
    public interface ICategoryUserReport
    {
        Task<List<CategoryUserEntity>>
            GetCategoriesByUserIdAsync(Guid userId,CancellationToken cancellation);

        Task<bool>CheckExistCategoryAsync(Guid userId,CancellationToken cancellation);

        Task<List<TModel>> GetUsersCategory<TModel>(Guid? CategoryId,
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
