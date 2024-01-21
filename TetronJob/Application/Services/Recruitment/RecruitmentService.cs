using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Recruitment
{
    public class RecruitmentService: IRecruitmentService
    {
        private readonly IEfRepository<RecruitmentEntity> _repository;

        public RecruitmentService(IEfRepository<RecruitmentEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(RecruitmentEntity recruitment, CancellationToken cancellation)
        {
            try
            {
                await _repository.InsertAsync(recruitment);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }

        public async Task<Response> UpdateAsync(RecruitmentEntity recruitment, CancellationToken cancellation)
        {
            try
            {
                await _repository.UpdateAsync(recruitment);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }

        public async Task<Response> DeleteAsync(RecruitmentEntity recruitment, CancellationToken cancellation)
        {
            try
            {
                await _repository.DeleteAsync(recruitment);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("خطای سمت سرور رخ داده است به پشتیبان اطلاع دهید.");
            }
        }
    }
}
