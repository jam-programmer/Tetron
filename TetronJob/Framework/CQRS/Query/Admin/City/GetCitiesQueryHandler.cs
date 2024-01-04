using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.City;
using Framework.ViewModels.City;
using MediatR;

namespace Framework.CQRS.Query.Admin.City
{
    public class GetCitiesQueryHandler:IRequestHandler<RequestCities,PaginatedList<CityViewModel>>
    {
        private readonly ICityFactory _cityFactory;

        public GetCitiesQueryHandler(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }
        public async Task<PaginatedList<CityViewModel>> Handle(RequestCities request, CancellationToken cancellationToken)
        {
            return await _cityFactory.GetPagedSearchWithSizeAsync<CityViewModel>(request.Paginated!, request.Id,
                cancellationToken);
        }
    }
}
