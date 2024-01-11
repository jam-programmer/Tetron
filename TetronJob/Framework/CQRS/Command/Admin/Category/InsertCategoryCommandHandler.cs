using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Category;
using Framework.ViewModels.Category;
using MediatR;

namespace Framework.CQRS.Command.Admin.Category
{
    public class InsertCategoryCommandHandler:IRequestHandler<InsertCategoryViewModel,Response>
    {
        private readonly ICategoryFactory _categoryFactory;

        public InsertCategoryCommandHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public async Task<Response> Handle(InsertCategoryViewModel request, CancellationToken cancellationToken)
        {
            return await _categoryFactory.InsertCategoryAsync(request, cancellationToken);
        }
    }
}
