using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Category;
using Framework.ViewModels.Category;
using MediatR;

namespace Framework.CQRS.Query.Admin.Category
{
    public class GetCategoriesHandler:IRequestHandler<RequestCategories,PaginatedList<CategoryViewModel>>
    {
        private readonly ICategoryFactory _categoryFactory;

        public GetCategoriesHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public Task<PaginatedList<CategoryViewModel>> Handle(RequestCategories request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
