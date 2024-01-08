using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Framework.ViewModels.Province
{
    public class ProvinceViewModel
    {
        public Guid Id { get; set; }
        public string? Name { set; get; }
    }

    public class RequestProvinces : IRequest<PaginatedList<ProvinceViewModel>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }

    public class DeleteProvinceViewModel : IRequest<Response>
    {
        public Guid Id { get; set; }

    }

    public class RequestGetProvinces:IRequest<List<ProvinceViewModel>>
    {

    }
}
