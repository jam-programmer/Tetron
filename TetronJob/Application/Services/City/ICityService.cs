using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.City
{
    public interface ICityService
    {
        Task<Response> InsertAsync(CityEntity city, CancellationToken cancellationToken);
        Task<Response> UpdateAsync(CityEntity city, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(CityEntity city, CancellationToken cancellationToken);
    }
}
