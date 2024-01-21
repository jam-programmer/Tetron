using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Skill
{
    public class SkillService:ISkillService
    {
        private readonly IEfRepository<SkillEntity> _repository;

        public SkillService(IEfRepository<SkillEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(SkillEntity skill, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.InsertAsync(skill);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
               //log
            }
            return response;
        }

        public async Task<Response> InsertAsync(List<SkillEntity> skills, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.InsertListAsync(skills);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }

        public async Task<Response> UpdateAsync(SkillEntity skill, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.UpdateAsync(skill);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }

        public async Task<Response> DeleteAsync(SkillEntity skill, CancellationToken cancellationToken)
        {
            Response response = new();
            try
            {
                await _repository.DeleteAsync(skill);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                //log
            }
            return response;
        }
    }
}
