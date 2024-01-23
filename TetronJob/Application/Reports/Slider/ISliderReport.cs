using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Reports.Slider
{
    public interface ISliderReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<SliderEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
