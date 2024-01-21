using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Introduction
{
    public interface IIntroductionService
    {
        Task<Response> InsertAsync(IntroductionEntity entity, CancellationToken cancellation);
        Task<Response> UpdateAsync(IntroductionEntity entity, CancellationToken cancellation);
        Task<Response> DeleteAsync(IntroductionEntity entity, CancellationToken cancellation);
    }

}
