using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Reports.Province;
using Application.Services.Province;

namespace Framework.Factories.Provinces
{
    public class ProvincesFactory:IProvincesFactory
    {
        private readonly IProvinceReport _report;
        private readonly IProvinceService _service;

        public ProvincesFactory(IProvinceReport report, IProvinceService service)
        {
            _report = report;
            _service = service;
        }
    }
}
