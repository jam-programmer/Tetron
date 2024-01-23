using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Query.Placement;

namespace Framework.Factories.Placement
{
    public interface IPlacementFactory
    {
        Task<List<CQRS.Query.Placement.Placement>>
            GetPlacementsWithFilter(GetPlacementWithFilterQuery query);
        Task<Response> InsertPlacementAsync(InsertPlacementCommand command, CancellationToken cancellation);
    }
}
