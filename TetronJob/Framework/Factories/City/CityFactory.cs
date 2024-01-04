using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.City;
using Application.Services.City;
using Domain.Entities;
using Framework.ViewModels.City;
using Mapster;

namespace Framework.Factories.City
{
    public class CityFactory:ICityFactory
    {
        private readonly ICityReport _report;
        private readonly ICityService _service;

        public CityFactory(ICityReport report, ICityService service)
        {
            _report = report;
            _service = service;
        }


          public async Task<PaginatedList<TViewModel>> 
              GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination, Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination,id, cancellationToken);
        }

        public async Task<Response> InsertCityAsync(InsertCityViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            CityEntity city = viewModel.Adapt<CityEntity>();
            var result = await _service.InsertAsync(city, cancellation);
            return result;
        }

        public async Task<Response> UpdateCityAsync(UpdateCityViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var city = await _report.GetByIdAsync(viewModel.Id, cancellation);
            city = viewModel.Adapt(city);
            
            var result = await _service.UpdateAsync(city, cancellation);
            return result;
        }

        public async Task<Response> DeleteCityAsync(DeleteCityViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var city = await _report.GetByIdAsync(viewModel.Id, cancellation);
            var result = await _service.DeleteAsync(city, cancellation);
            return result;
        }

        public async Task<UpdateCityViewModel> GetCityByIdAsync(RequestGetCityById request, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var city = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateCityViewModel command = city.Adapt<UpdateCityViewModel>();
            return command;
        }
 
    }
}
