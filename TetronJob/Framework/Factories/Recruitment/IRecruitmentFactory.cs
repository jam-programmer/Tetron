using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Master.Recruitment;

namespace Framework.Factories.Recruitment
{
    public interface IRecruitmentFactory
    {
        Task<Response> InsertRecruitmentAsync(InsertRecruitmentCommand command, CancellationToken cancellation);
    }
}
