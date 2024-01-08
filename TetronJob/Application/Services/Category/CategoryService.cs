using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Category
{
    public class CategoryService:ICategoryService
    {
        private readonly IEfRepository<CategoryEntity> _repository;

        public CategoryService(IEfRepository<CategoryEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Response> InsertAsync(CategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.InsertAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(CategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.UpdateAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> DeleteAsync(CategoryEntity category, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.DeleteAsync(category);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }
    }
}
