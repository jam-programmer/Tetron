using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PictureEntity:BaseEntity
    {
        public Guid? ParentId { set; get; }
        public string? Path { set; get; }
    }
}
