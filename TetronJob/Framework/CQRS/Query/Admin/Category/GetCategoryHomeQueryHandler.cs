using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Category;
using MediatR;

namespace Framework.CQRS.Query.Admin.Category
{
    public class GetCategoryHomeQueryHandler:IRequestHandler<GetCategoryHomeQuery, IEnumerable<Category>>
    {
        private readonly ICategoryFactory _categoryFactory;

        public GetCategoryHomeQueryHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public async Task<IEnumerable<Category>> Handle(GetCategoryHomeQuery request, CancellationToken cancellationToken)
        {
            return await _categoryFactory.GetCategoryForHomePageAsync();
        }
    }

    public class GetCategoryHomeQuery:IRequest<IEnumerable<Category>>
    {

    }
    public class Category
    {
        public string? Name { set; get; }
        public string? Color { set; get; }
        public string? Image { set; get; }
        public Guid Id { set; get; }
    }
}
