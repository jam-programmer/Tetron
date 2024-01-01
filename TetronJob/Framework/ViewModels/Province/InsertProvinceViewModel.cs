using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Province
{
    public class InsertProvinceViewModel:IRequest<Response>
    {
 
        public string? Name { set; get; }
    }
}
