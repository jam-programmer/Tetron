using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Category;
using Framework.ViewModels.Category;
using MediatR;

namespace Framework.CQRS.Query.Admin.Category
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<RequestGetCategoryById,UpdateCategoryViewModel>
    {
        private readonly ICategoryFactory _categoryFactory;

        public GetCategoryByIdQueryHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public Task<UpdateCategoryViewModel> Handle(RequestGetCategoryById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
