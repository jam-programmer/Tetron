using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkillEntity:BaseEntity
    {
        public string? SkillName { set; get; }
        public ICollection<SkillIntroductionEntity>? SkillIntroduction { set; get; }

    }
}
