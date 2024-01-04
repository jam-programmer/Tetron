using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.ViewModels.Province;
using MediatR;

namespace Framework.ViewModels.City
{
    public class UpdateCityViewModel:IRequest<Response>
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public string? Name { get; set; }
    }
    public class RequestGetCityById : IRequest<UpdateCityViewModel>
    {
        public Guid Id { get; set; }

    }
}
