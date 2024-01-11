using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SkillIntroductionEntity:BaseEntity
    {
        public Guid? SkillId { set; get; }
        public SkillEntity? Skill { set; get; }
        public Guid? IntroductionId { set; get; }
        public IntroductionEntity? Introduction { set; get; }
    }
}
