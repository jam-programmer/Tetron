using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.CategoryUser
{
    public class CategoryUserService:ICategoryUserService
    {
        private readonly IEfRepository<CategoryUserEntity> _repository;

        public CategoryUserService(IEfRepository<CategoryUserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(List<CategoryUserEntity> categoryUser, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {

            }

            try
            {
                await _repository.InsertListAsync(categoryUser);
                response.IsSuccess = true;
            }
            catch (Exception w)
            {
               //
            }
            return response;
        }

        public async Task<Response> DeleteAsync(List<CategoryUserEntity> categoryUser, CancellationToken cancellation)
        {
            Response response = new();
            if (cancellation.IsCancellationRequested)
            {

            }

            try
            {
                await _repository.DeleteListAsync(categoryUser);
                response.IsSuccess = true;
            }
            catch (Exception w)
            {
                //
            }
            return response;
        }
    }
}
