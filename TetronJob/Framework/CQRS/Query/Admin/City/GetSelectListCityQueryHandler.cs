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
    public class GetSelectListCityQueryHandler
    :IRequestHandler<RequestGetCities,List<CityViewModel>>
    {
        private readonly ICityFactory _cityFactory;

        public GetSelectListCityQueryHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }
        public async Task<List<CityViewModel>> Handle(RequestGetCities request, CancellationToken cancellationToken)
        {
            return await _cityFactory.GetCitiesAsync(request.Id);
        }
    }
}
