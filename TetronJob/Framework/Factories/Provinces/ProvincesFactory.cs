using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.Province;
using Application.Services.Province;
using Domain.Entities;
using Framework.ViewModels.Province;
using Mapster;

namespace Framework.Factories.Provinces
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
            province=viewModel.Adapt<ProvinceEntity>();
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
