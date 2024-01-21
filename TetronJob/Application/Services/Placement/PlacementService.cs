using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Placement
{
    public class PlacementService: IPlacementService
    {
        private readonly IEfRepository<PlacementEntity> _repository;

        public PlacementService(IEfRepository<PlacementEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(PlacementEntity entity, CancellationToken cancellation)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }

        public async Task<Response> UpdateAsync(PlacementEntity entity, CancellationToken cancellation)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }

        public async Task<Response> DeleteAsync(PlacementEntity entity, CancellationToken cancellation)
        {
            try
            {
                await _repository.DeleteAsync(entity);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }
    }
}
