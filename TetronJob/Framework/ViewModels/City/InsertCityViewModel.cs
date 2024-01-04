using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.City
{
    public class InsertCityViewModel:IRequest<Response>
    {
        public Guid ProvinceId { get; set; }
        public string? Name { get; set; }
    }
}
