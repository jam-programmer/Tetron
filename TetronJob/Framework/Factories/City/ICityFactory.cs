using Application.Models;
using Framework.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Factories.City
{
    public interface ICityFactory
    {
        Task<List<CityViewModel>> GetCitiesAsync(Guid id);
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,Guid id,
            CancellationToken cancellationToken = default);

        Task<Response> InsertCityAsync(InsertCityViewModel viewModel, CancellationToken cancellation);
        Task<Response> UpdateCityAsync(UpdateCityViewModel viewModel, CancellationToken cancellation);
        Task<Response> DeleteCityAsync(DeleteCityViewModel viewModel, CancellationToken cancellation);
        Task<UpdateCityViewModel> GetCityByIdAsync(RequestGetCityById request, CancellationToken cancellation);

    }
}
