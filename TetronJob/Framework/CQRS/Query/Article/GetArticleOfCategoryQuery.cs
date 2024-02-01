using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Article;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Framework.CQRS.Query.Article
{
    public class GetArticleOfCategoryQuery : IRequest<PaginatedList<ArticleOfCategory>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
        public Guid Id { set; get; }
    }

    public class
        GetArticleOfCategoryQueryHandler : IRequestHandler<GetArticleOfCategoryQuery, PaginatedList<ArticleOfCategory>>
    {
        private readonly IArticleFactory _articleFactory;

        public GetArticleOfCategoryQueryHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<PaginatedList<ArticleOfCategory>> Handle(GetArticleOfCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _articleFactory.GetPagedSearchWithSizeAsync<ArticleOfCategory>(request.Paginated, request.Id,
                cancellationToken);
        }
    }
    public class ArticleOfCategory
    {
        public Guid Id { set; get; }
        public string ArticleTitle { set; get; }
        public string ArticleImage { set; get; }
        public DateTime CreateTime { set; get; }


        public string ConvertToPersianDate(DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            string PersinaTime = pc.ToDateTime(pc.GetYear(time), pc.GetMonth(time), pc.GetDayOfMonth(time), 0, 0, 0, 0).ToString();
            return PersinaTime;
        }
    }
}
