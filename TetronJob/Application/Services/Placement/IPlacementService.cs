using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Placement
{
    public interface IPlacementService
    {
        Task<Response> InsertAsync(PlacementEntity entity, CancellationToken cancellation);
        Task<Response> UpdateAsync(PlacementEntity entity, CancellationToken cancellation);
        Task<Response> DeleteAsync(PlacementEntity entity, CancellationToken cancellation);
    }                                            
}
