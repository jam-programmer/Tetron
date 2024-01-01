using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Province
{
    public class UpdateProvinceViewModel:IRequest<Response>
    {
        public Guid Id { get; set; }
        public string? Name { set; get; }
    }

    public class RequestGetProvinceById : IRequest<UpdateProvinceViewModel>
    {
        public Guid Id { get; set; }
       
    }
}
