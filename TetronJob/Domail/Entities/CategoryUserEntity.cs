using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryUserEntity:BaseEntity
    {
        public Guid UserId { set; get; }
        public UserEntity? User { set; get; }
        public Guid CategoryId { set; get; }
        public CategoryEntity? Category { set; get; }

    }
}
