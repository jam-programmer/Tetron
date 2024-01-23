using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ArticleEntity:BaseEntity
    {
        public string ArticleTitle { set; get; }
        public string ArticleImage { set; get; }
        public int VisitCount { set; get; }
 
        public string ArticleBody { set; get; }
        public string ArticleTags { set; get; }

        public Guid ArticleCategoryId { set; get; }
        public ArticleCategoryEntity Category { set; get; }
    }
}
