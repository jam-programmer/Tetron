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
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryViewModel,Response>
    {
        private readonly ICategoryFactory _categoryFactory;

        public DeleteCategoryCommandHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public async Task<Response> Handle(DeleteCategoryViewModel request, CancellationToken cancellationToken)
        {
            return await _categoryFactory.DeleteCategoryAsync(request, cancellationToken);
        }
    }
}
