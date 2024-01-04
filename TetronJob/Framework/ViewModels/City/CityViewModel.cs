using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Framework.ViewModels.City
{
    public class CityViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ProvinceName { get; set; }
    }
    public class DeleteCityViewModel : IRequest<Response>
    {
        public Guid Id { get; set; }

    }
    public class RequestCities:IRequest<PaginatedList<CityViewModel>>
    {
        public Guid Id { get; set; }
        public PaginatedSearchWithSize? Paginated { set; get; }
    }
}
