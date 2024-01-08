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
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryViewModel,Response>
    {
        private readonly ICategoryFactory _categoryFactory;

        public UpdateCategoryCommandHandler(ICategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }
        public Task<Response> Handle(UpdateCategoryViewModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
