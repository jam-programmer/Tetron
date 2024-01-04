using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.City
{
    public class CityService:ICityService
    {
        private readonly IEfRepository<CityEntity> _repository;

        public CityService(IEfRepository<CityEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Response> InsertAsync(CityEntity city, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.InsertAsync(city);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(CityEntity city, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.UpdateAsync(city);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> DeleteAsync(CityEntity city, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.DeleteAsync(city);
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
