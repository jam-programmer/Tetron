using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.Province
{
    public interface IProvinceService
    {
        Task<Response>InsertAsync(ProvinceEntity province,CancellationToken cancellationToken);
        Task<Response>UpdateAsync(ProvinceEntity province,CancellationToken cancellationToken);
        Task<Response>DeleteAsync(ProvinceEntity province,CancellationToken cancellationToken);

    }
}
