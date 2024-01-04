using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.City;
using Framework.ViewModels.City;
using MediatR;

namespace Framework.CQRS.Query.Admin.City
{
    public class GetCityByIdQueryHandler:IRequestHandler<RequestGetCityById,UpdateCityViewModel>
    {
        private readonly ICityFactory _cityFactory;

        public GetCityByIdQueryHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }

        public async Task<UpdateCityViewModel> Handle(RequestGetCityById request, CancellationToken cancellationToken)
        {
            return await _cityFactory.GetCityByIdAsync(request, cancellationToken);
        }
    }
}
