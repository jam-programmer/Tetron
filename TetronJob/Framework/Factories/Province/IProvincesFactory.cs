using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.ViewModels.City;
using Framework.ViewModels.Province;

namespace Framework.Factories.Province
{
    public interface IProvincesFactory
    {
        Task<List<ProvinceViewModel>> GetProvincesAsync();
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response>InsertProvinceAsync(InsertProvinceViewModel  viewModel,CancellationToken cancellation);
        Task<Response>UpdateProvinceAsync(UpdateProvinceViewModel  viewModel,CancellationToken cancellation);
        Task<Response>DeleteProvinceAsync(DeleteProvinceViewModel  viewModel,CancellationToken cancellation);
        Task<UpdateProvinceViewModel> GetProvinceByIdAsync(RequestGetProvinceById  request,CancellationToken cancellation);
    }
}
