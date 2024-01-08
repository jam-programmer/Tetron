using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.ViewModels.Category
{
    public class InsertCategoryViewModel : IRequest<Response>
    {
        public string? Name { set; get; }
        public string? Color { set; get; }
        public IFormFile? File { set; get; }
    }
}