using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Master.Placement;

namespace Framework.Factories.Placement
{
    public interface IPlacementFactory
    {
        Task<Response> InsertPlacementAsync(InsertPlacementCommand command, CancellationToken cancellation);
    }
}
