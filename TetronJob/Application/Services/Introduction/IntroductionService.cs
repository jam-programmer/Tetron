using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Application.Services.Introduction
{
    public class IntroductionService: IIntroductionService
    {
        private readonly IEfRepository<IntroductionEntity> _repository;

        public IntroductionService(IEfRepository<IntroductionEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(IntroductionEntity entity, CancellationToken cancellation)
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

        public async Task<Response> UpdateAsync(IntroductionEntity entity, CancellationToken cancellation)
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

        public async Task<Response> DeleteAsync(IntroductionEntity entity, CancellationToken cancellation)
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
