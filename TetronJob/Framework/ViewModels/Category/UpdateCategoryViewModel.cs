using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.ViewModels.Category
{
    public class UpdateCategoryViewModel:IRequest<Response>
    {
        public string? Name { set; get; }
        public string? Color { set; get; }
        public IFormFile? File { set; get; }
        public Guid Id { set; get; }
        public string? Path { set; get; }
    }

    public class RequestGetCategoryById : IRequest<UpdateCategoryViewModel>
    {
        public Guid Id { set; get; }
    }
}
