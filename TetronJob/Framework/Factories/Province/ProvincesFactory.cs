
using Application.Models;
using Application.Reports.Province;
using Application.Services.Province;
using Domain.Entities;

using Framework.ViewModels.Province;
using Mapster;

namespace Framework.Factories.Province
{
    public class ProvincesFactory:IProvincesFactory
    {
        private readonly IProvinceReport _report;
        private readonly IProvinceService _service;

        public ProvincesFactory(IProvinceReport report, IProvinceService service)
        {
            _report = report;
            _service = service;
        }

        public async Task<List<ProvinceViewModel>> GetProvincesAsync()
        {
            var items= await _report.GetProvinces();
            List<ProvinceViewModel> provinces= items.Adapt<List<ProvinceViewModel>>();
            return provinces;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertProvinceAsync(InsertProvinceViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            ProvinceEntity province = viewModel.Adapt<ProvinceEntity>();
            var result = await _service.InsertAsync(province, cancellation);
            return result;
        }

        public async Task<Response> UpdateProvinceAsync(UpdateProvinceViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var province = await _report.GetByIdAsync(viewModel.Id, cancellation);
            province.Name=viewModel.Name;
            
            var result = await _service.UpdateAsync(province, cancellation);
            return result;
        }

        public async Task<Response> DeleteProvinceAsync(DeleteProvinceViewModel viewModel, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var province = await _report.GetByIdAsync(viewModel.Id, cancellation);
            var result = await _service.DeleteAsync(province, cancellation);
            return result;
        }

        public async Task<UpdateProvinceViewModel> GetProvinceByIdAsync(RequestGetProvinceById request, CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                //todo
            }

            var province = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateProvinceViewModel command = province.Adapt<UpdateProvinceViewModel>();
            return command;
        }
    }
}
