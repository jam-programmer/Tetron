using Application.Models;
using MediatR;

namespace Framework.ViewModels.Category
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

    }

    public class RequestGetCategories:IRequest<IEnumerable<CategoryViewModel>>
    {

    }
    public class RequestCategories : IRequest<PaginatedList<CategoryViewModel>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }

    public class DeleteCategoryViewModel : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
