using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Master.Introduction;

namespace Framework.Factories.Introduction
{
    public interface IIntroductionFactory
    {
        Task<Response> InsertIntroductionAsync(InsertIntroductionCommand command, CancellationToken cancellationToken);
    }
}
