using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CategoryEntity:BaseEntity,IBase
    {
        public string? Name { set; get; }
        public string? Color { set; get; }
        public string? Image { set; get; }
        public ICollection<CategoryUserEntity>? CategoryUsers { set; get; }
       
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
