using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.Category;
using Application.Reports.CategoryUser;
using Application.Services.Category;
using Domain.Entities;
using Framework.Common.Application.Core;
using Framework.CQRS.Query.Admin.Category;
using Framework.ViewModels.Category;
using Mapster;

namespace Framework.Factories.Category
{
    public class CategoryFactory:ICategoryFactory
    {
        private readonly ICategoryReport _report;
        private readonly ICategoryService _service;
        private readonly ICategoryUserReport _categoryUserReport;

        public CategoryFactory(ICategoryReport report, ICategoryService service, ICategoryUserReport categoryUserReport)
        {
            _report = report;
            _service = service;
            _categoryUserReport = categoryUserReport;
        }
        public async Task<UserCategoryResult> GetUsersCategory(CategoryFilter filter)
        {
            var model = await _categoryUserReport
                .GetUsersCategory<UsersCategory>(filter.CategoryId, filter.CityId, filter.ProvinceId, filter.Search);
            UserCategoryResult result = new();
            result.Users = model;
            result.Filter = filter;
            return result;
        }

        public async Task<IEnumerable<CQRS.Query.Admin.Category.Category>> GetCategoryForHomePageAsync()
        {
            var result = await _report.GetAllCategoriesAsync();
            var response = result.Adapt<IEnumerable<CQRS.Query.Admin.Category.Category>>();
            return response;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertCategoryAsync(InsertCategoryViewModel viewModel, CancellationToken cancellation)
        {
            CategoryEntity category =  viewModel.Adapt<CategoryEntity>();
            category.Image = FileProcessing.FileUpload(viewModel.File, null, "CategoryImage");
                return await _service.InsertAsync(category,cancellation);
        }

        public async Task<Response> UpdateCategoryAsync(UpdateCategoryViewModel viewModel, CancellationToken cancellation)
        {
            var category = await _report.GetByIdAsync(viewModel.Id, cancellation);
            category = viewModel.Adapt<CategoryEntity>();
            category.Image = FileProcessing.FileUpload(viewModel.File, viewModel.Path, "CategoryImage");
            return await _service.UpdateAsync(category, cancellation);
        }

        public async Task<Response> DeleteCategoryAsync(DeleteCategoryViewModel viewModel, CancellationToken cancellation)
        {
            var category = await _report.GetByIdAsync(viewModel.Id, cancellation);
            var result = await _service.DeleteAsync(category, cancellation);
            if (result.IsSuccess == true)
            {
                FileProcessing.RemoveFile(category.Name!, "CategoryImage");
            }

            return result;
        }

        public async Task<UpdateCategoryViewModel> GetCategoryByIdAsync(RequestGetCategoryById request, CancellationToken cancellation)
        {
        
            var category = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateCategoryViewModel updateCategory = category.Adapt<UpdateCategoryViewModel>();
            updateCategory.Path = category.Image;
            return updateCategory;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await _report.GetAllCategoriesAsync();
            IEnumerable<CategoryViewModel> categoryViewModels = categories.Adapt<IEnumerable<CategoryViewModel>>();
            return categoryViewModels;
        }
    }
}
