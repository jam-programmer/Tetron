using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Province
{
    public class ProvinceService:IProvinceService
    {
        private readonly IEfRepository<ProvinceEntity> _repository;

        public ProvinceService(IEfRepository<ProvinceEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(ProvinceEntity province, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.InsertAsync(province);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> UpdateAsync(ProvinceEntity province, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.UpdateAsync(province);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return response;
        }

        public async Task<Response> DeleteAsync(ProvinceEntity province, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            Response response = new();
            try
            {
                await _repository.DeleteAsync(province);
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
