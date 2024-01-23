using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ArticleCategoryEntity:BaseEntity
    {
        public string ArticleCategoryTitle { set; get; }
        public ICollection<ArticleEntity> Article { set; get; }
    }
}
