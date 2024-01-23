using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Reports.Introduction
{
    public interface IIntroductionReport
    {
        Task<List<IntroductionEntity>> GetIntroductions(
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
