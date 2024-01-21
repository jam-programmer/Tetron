using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.Recruitment
{
    public interface IRecruitmentService
    {
        Task<Response> InsertAsync(RecruitmentEntity recruitment , CancellationToken cancellation);
        Task<Response> UpdateAsync(RecruitmentEntity recruitment , CancellationToken cancellation);
        Task<Response> DeleteAsync(RecruitmentEntity recruitment , CancellationToken cancellation);

    }
}
